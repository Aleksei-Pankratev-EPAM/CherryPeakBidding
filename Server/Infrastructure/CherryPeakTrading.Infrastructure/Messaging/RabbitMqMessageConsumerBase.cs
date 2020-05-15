using CherryPeakTrading.Data.Contracts.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Text;

namespace CherryPeakTrading.Infrastructure.Messaging
{
    public abstract class RabbitMqMessageConsumerBase<T> : IMessageConsumer<T> where T : class
    {
        private readonly IRabbitMqChannelProvider _rabbitMqChannelProvider;
        private readonly IMessagePublisher<FailedMessage<T>> _failedMessagePublisher;
        private readonly ILogger _logger;
        private readonly IRabbitMqQueueBuilder<T> _queueBuilder;
        private readonly bool _sendToFailedQueue;
        private EventingBasicConsumer? _basicConsumer;
        

        protected RabbitMqMessageConsumerBase(
            IRabbitMqChannelProvider rabbitMqChannelProvider,
            IMessagePublisher<FailedMessage<T>> failedMessagePublisher,
            IRabbitMqQueueBuilder<T> queueBuilder,
            ILogger logger)
        {
            _rabbitMqChannelProvider = rabbitMqChannelProvider;
            _failedMessagePublisher = failedMessagePublisher;
            _logger = logger;

            _queueBuilder = queueBuilder;
            _sendToFailedQueue = !_queueBuilder.IsFailedMessageQueue();
        }

        public void StartListening()
        {
            var queueName = _queueBuilder.GetQueueName();
            _logger.Information("Start listening queue {queueName}", queueName);

            var channel = _rabbitMqChannelProvider.OpenChannel();

            _queueBuilder.EnsureCreated(channel);

            _basicConsumer = new EventingBasicConsumer(channel);
            _basicConsumer.Received += OnMessageReceived;
            channel.BasicConsume(
                queue: queueName,
                autoAck: false,
                consumer: _basicConsumer,
                consumerTag: "",
                exclusive: false,
                noLocal: false,
                arguments: null);
        }

        private void OnMessageReceived(object? sender, BasicDeliverEventArgs e)
        {
            var messageId = e.BasicProperties.MessageId;
            _logger.Information("Message received {messageId}", messageId);

            var body = e.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);
            var message = JsonConvert.DeserializeObject<T>(json);
            var deliveryTag = e.DeliveryTag;
            try
            {
                Consume(message);
                _logger.Information("Message consumed {messageId}", messageId);
                Ack(deliveryTag);
            }
            catch (Exception ex)
            {
                var firstFailure = !e.Redelivered;

                if (firstFailure)
                {
                    HandleFirstError(deliveryTag, messageId, ex);
                }
                else
                {
                    HandleSecondError(deliveryTag, messageId, message, ex);
                }
            }
        }

        public abstract void Consume(T message);

        public void StopListening()
        {
            if (_basicConsumer == null)
                throw new InvalidOperationException("Cannot stop not running consumer");

            var queueName = _queueBuilder.GetQueueName();
            _logger.Information("Stop listening queue {queueName}", queueName);

            _basicConsumer.Received -= OnMessageReceived;
            _basicConsumer = null;
        }

        #region Private Methods

        /// <summary>
        /// First-chance error handler for messages that failed to be consumed: resend them back to the queue.
        /// </summary>
        private void HandleFirstError(in ulong deliveryTag, string messageId, Exception exception)
        {
            _logger.Error("Message was not consumed, first attempt {messageId}, {exception}",
                messageId, exception);

            Nack(deliveryTag);
        }

        /// <summary>
        /// Handler for the second error happened on the same message: put them into a failed messages queue
        /// and forget.
        /// </summary>
        private void HandleSecondError(in ulong deliveryTag, string messageId, T message, Exception exception)
        {
            _logger.Error("Message was not consumed, second attempt {messageId}, {exception}. Discard it as failed",
                messageId, exception);

            if (_sendToFailedQueue)
            {
                _failedMessagePublisher.Publish(new FailedMessage<T>(messageId, message));
            }

            Ack(deliveryTag);
        }

        /// <summary>
        /// Acknowledge the message
        /// </summary>
        private void Ack(ulong deliveryTag)
        {
            _basicConsumer?.Model.BasicAck(deliveryTag, multiple: false);
        }

        /// <summary>
        /// Negative acknowledge of the message: mark it as undelivered.
        /// </summary>
        private void Nack(ulong deliveryTag)
        {
            _basicConsumer?.Model.BasicNack(deliveryTag, multiple: false, requeue: true);
        }

        #endregion Private Methods
    }
}
