using CherryPeakTrading.BL.Contracts.Messages;
using CherryPeakTrading.Infrastructure.Contracts.Messaging;
using CherryPeakTrading.Infrastructure.Messaging;
using Serilog;

namespace CherryPeakTrading.WorkerService.Consumers
{
    internal class BidCreatedConsumer : RabbitMqMessageConsumerBase<BidCreatedMessage>
    {
        public BidCreatedConsumer(
            IRabbitMqChannelProvider rabbitMqChannelProvider,
            IMessagePublisher<FailedMessage<BidCreatedMessage>> failedMessagePublisher,
            IRabbitMqQueueBuilder<BidCreatedMessage> queueBuilder,
            ILogger logger)
            : base(rabbitMqChannelProvider, failedMessagePublisher, queueBuilder, logger)
        {
        }

        public override void Consume(BidCreatedMessage message)
        {
            //TODO Add message processing logic
        }
    }
}
