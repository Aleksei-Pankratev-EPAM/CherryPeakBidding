namespace CherryPeakTrading.Infrastructure.Contracts.Messaging
{
    /// <summary>
    /// A generic interface for publishing messages to a message queue.
    /// </summary>
    /// <typeparam name="T">Type of messages to publish.</typeparam>
    public interface IMessagePublisher<T> where T : class
    {
        /// <summary>
        /// Send a message to the default queue associated with this type of messages.
        /// </summary>
        void Publish(T message);
    }
}
