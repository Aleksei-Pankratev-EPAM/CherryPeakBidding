namespace CherryPeakTrading.Infrastructure.Contracts.Messaging
{
    public interface IMessageConsumer
    {
        void StartListening();

        void StopListening();
    }

    public interface IMessageConsumer<T> : IMessageConsumer
        where T : class
    {
        void Consume(T message);
    }
}
