using CherryPeakTrading.Infrastructure.Contracts.Messaging;
using RabbitMQ.Client;

namespace CherryPeakTrading.Infrastructure.Messaging
{
    /// <summary>
    /// Channel provider for RabbitMQ that stores opened channel between calls.
    /// Since the same channel should not be used concurrently (see https://www.rabbitmq.com/dotnet-api-guide.html#connection-and-channel-lifspan)
    /// this provider's scope must be either `Thread` (not supported by MS DI), or `Scoped`.
    /// </summary>
    internal class RabbitMqChannelProvider : IRabbitMqChannelProvider
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection? _connection;
        private IModel? _channel;

        public RabbitMqChannelProvider(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Open a new channel or return the previously open one if it is still alive.
        /// </summary>
        public IModel OpenChannel()
        {
            _connection ??= _connectionFactory.CreateConnection();

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
