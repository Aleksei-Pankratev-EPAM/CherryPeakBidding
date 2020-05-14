using RabbitMQ.Client;

namespace CherryPeakTrading.Infrastructure.Messaging
{
    public interface IRabbitMqChannelProvider
    {
        IModel OpenChannel();
    }
}
