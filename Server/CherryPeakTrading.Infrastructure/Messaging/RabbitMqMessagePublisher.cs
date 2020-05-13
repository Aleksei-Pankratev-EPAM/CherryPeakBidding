using CherryPeakTrading.Data.Contracts.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
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
        private readonly RabbitMqChannelProvider _rabbitMqChannelProvider;

        public RabbitMqMessagePublisher(RabbitMqChannelProvider rabbitMqChannelProvider)
        {
            _rabbitMqChannelProvider = rabbitMqChannelProvider;
        }

        public void Publish(T message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var channel = _rabbitMqChannelProvider.OpenChannel();
            var exchangeName = GetExchangeName();
            var routingKey = GetRoutingKey(message);
            var queueName = GetQueueName();
            var body = Serialize(message);
            var props = channel.CreateBasicProperties();
            props.Persistent = true;

            channel.QueueDeclare(queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            channel.BasicPublish(exchangeName, routingKey, props, body);
        }

        #region Protected Methods

        protected virtual string GetExchangeName()
        {
            return string.Empty;
        }

        protected virtual string GetQueueName()
        {
            return typeof(T).FullName ?? typeof(T).Name;
        }

        protected virtual string GetRoutingKey(T message)
        {
            return typeof(T).FullName ?? typeof(T).Name;
        }

        protected virtual byte[] Serialize(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            return Encoding.UTF8.GetBytes(json);
        }

        #endregion Protected Methods
    }
}
