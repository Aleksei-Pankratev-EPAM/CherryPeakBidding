using CherryPeakTrading.BL.Contracts.Messages;
using CherryPeakTrading.Infrastructure.Contracts.Messaging;
using CherryPeakTrading.Infrastructure.Messaging;
using Serilog;

namespace CherryPeakTrading.WorkerService.Consumers
{
    internal class LotCreatedConsumer : RabbitMqMessageConsumerBase<LotCreatedMessage>
    {
        public LotCreatedConsumer(
            IRabbitMqChannelProvider rabbitMqChannelProvider,
            IMessagePublisher<FailedMessage<LotCreatedMessage>> failedMessagePublisher,
            IRabbitMqQueueBuilder<LotCreatedMessage> queueBuilder,
            ILogger logger)
            : base(rabbitMqChannelProvider, failedMessagePublisher, queueBuilder, logger)
        {
        }

        public override void Consume(LotCreatedMessage message)
        {
            //TODO Add message processing logic
        }
    }
}
