using CherryPeakTrading.Infrastructure.Messaging;
using NUnit.Framework;

namespace CherryPeakTrading.Infrastructure.Tests.Messaging
{
    public class RabbitMqDefaultQueueBuilderTests
    {
        [Test]
        public void ExchangeNameIsEmpty()
        {
            var builder = new RabbitMqDefaultQueueBuilder<TestMessage>();

            var exchangeName = builder.GetExchangeName();
            Assert.AreEqual(string.Empty, exchangeName);
        }

        [Test]
        public void QueueNameForSimpleMessage_IsSameAsClassName()
        {
            var builder = new RabbitMqDefaultQueueBuilder<TestMessage>();

            var queueName = builder.GetQueueName();
            Assert.AreEqual("CherryPeakTrading.Infrastructure.Tests.Messaging.TestMessage", queueName);
        }

        [Test]
        public void QueueNameForFailedMessage_IsFailedMessagePlusClassName()
        {
            var builder = new RabbitMqDefaultQueueBuilder<FailedMessage<TestMessage>>();

            var queueName = builder.GetQueueName();
            Assert.AreEqual("FailedMessage<CherryPeakTrading.Infrastructure.Tests.Messaging.TestMessage>", queueName);
        }
    }
    public class TestMessage
    {
        public string Name { get; set; } = "Test";
    }
}
