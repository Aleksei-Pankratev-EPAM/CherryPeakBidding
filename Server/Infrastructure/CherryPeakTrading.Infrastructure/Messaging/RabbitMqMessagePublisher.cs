using CherryPeakTrading.Infrastructure.Contracts.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Serilog;
using System;
using System.Text;

namespace CherryPeakTrading.Infrastructure.Messaging
{
    /// <summary>
    /// A simple message publisher that sends all messages to the default exchange, using
    /// a message type as a queue name.
    /// </summary>
    internal class RabbitMqMessagePublisher<T> : IMessagePublisher<T> where T : class
    {
        private readonly IRabbitMqChannelProvider _rabbitMqChannelProvider;
        private readonly ILogger _logger;
        private readonly RabbitMqDefaultQueueBuilder<T> _queueBuilder;

        public RabbitMqMessagePublisher(
            IRabbitMqChannelProvider rabbitMqChannelProvider,
            ILogger logger)
        {
            _rabbitMqChannelProvider = rabbitMqChannelProvider;
            _logger = logger;
            _queueBuilder = new RabbitMqDefaultQueueBuilder<T>();
        }

        public void Publish(T message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var channel = _rabbitMqChannelProvider.OpenChannel();
            var exchangeName = _queueBuilder.GetExchangeName();
            var routingKey = _queueBuilder.GetRoutingKey(message);
            var queueName = _queueBuilder.GetQueueName();
            var body = Serialize(message);
            var props = channel.CreateBasicProperties();
            props.Persistent = true;
            props.MessageId = Guid.NewGuid().ToString();

            channel.QueueDeclare(queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.BasicPublish(exchangeName, routingKey, props, body);
            _logger.Information("Message published to {queueName}: {messageId}",
                queueName,
                props.MessageId);
        }

        #region Protected Methods

        protected virtual byte[] Serialize(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            return Encoding.UTF8.GetBytes(json);
        }

        #endregion Protected Methods
    }
}
