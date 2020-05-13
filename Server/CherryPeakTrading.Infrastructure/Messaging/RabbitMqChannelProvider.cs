using RabbitMQ.Client;

namespace CherryPeakTrading.Infrastructure.Messaging
{
    /// <summary>
    /// Channel provider for RabbitMQ that stores opened channel between calls.
    /// Since the same channel should not be used concurrently (see https://www.rabbitmq.com/dotnet-api-guide.html#connection-and-channel-lifspan)
    /// this provider's scope must be either `Thread` (not supported by MS DI), or `Scoped`.
    /// </summary>
    internal class RabbitMqChannelProvider
    {
        private readonly IConnection _connection;
        private IModel? _channel;

        public RabbitMqChannelProvider(IConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Open a new channel or return the previously open one if it still alive.
        /// </summary>
        public IModel OpenChannel()
        {
            if (_channel != null && _channel.IsClosed)
            {
                _channel.Dispose();
                _channel = null;
            }

            if (_channel == null)
            {
                _channel = _connection.CreateModel();
            }

            return _channel;
        }
    }
}
