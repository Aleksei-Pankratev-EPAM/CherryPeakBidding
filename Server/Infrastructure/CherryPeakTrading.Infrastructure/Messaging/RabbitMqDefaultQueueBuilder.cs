using CherryPeakTrading.Infrastructure.Contracts.Messaging;
using RabbitMQ.Client;
using System;
using System.Linq;

namespace CherryPeakTrading.Infrastructure.Messaging
{
    /// <summary>
    /// A builder creating default queue based on a message type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class RabbitMqDefaultQueueBuilder<T> : IRabbitMqQueueBuilder<T>
    {
        public string GetExchangeName()
        {
            return string.Empty;
        }

        public string GetRoutingKey(T message)
        {
            return GetQueueName();
        }

        public string GetQueueName()
        {
            if (IsFailedMessageQueue())
            {
                var originalMethodType = typeof(T).GenericTypeArguments.Single();
                return $"FailedMessage<{GetClassName(originalMethodType)}>";
            }

            return GetClassName(typeof(T));
        }

        /// <summary>
        /// Check if the current message type is one of <see cref="FailedMessage{T}"/> - for such messages
        /// we do not perform resending to a failed messages queue.
        /// </summary>
        public bool IsFailedMessageQueue()
        {
            var typeOfT = typeof(T);
            return typeOfT.IsGenericType &&
                   typeOfT.GetGenericTypeDefinition() == typeof(FailedMessage<>);
        }

        public void EnsureCreated(IModel channel)
        {
            channel.QueueDeclare(
                queue: GetQueueName(),
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        private string GetClassName(Type type)
        {
            return type.FullName ?? type.Name;
        }
    }
}
