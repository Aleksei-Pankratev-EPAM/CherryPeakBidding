using RabbitMQ.Client;

namespace CherryPeakTrading.Infrastructure.Messaging
{
    public interface IRabbitMqQueueBuilder<T>
    {
        string GetExchangeName();

        string GetRoutingKey(T message);

        string GetQueueName();

        /// <summary>
        /// Check if the current message type is one of <see cref="FailedMessage{T}"/> - for such messages
        /// we do not perform resending to a failed messages queue.
        /// </summary>
        bool IsFailedMessageQueue();

        void EnsureCreated(IModel channel);
    }
}
