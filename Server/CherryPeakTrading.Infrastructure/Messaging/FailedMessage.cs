namespace CherryPeakTrading.Infrastructure.Messaging
{
    /// <summary>
    /// A container class for messages failed to be consumed.
    /// </summary>
    /// <typeparam name="T">Type of the original message</typeparam>
    public class FailedMessage<T> where T: class
    {
        public string OriginalId { get; }

        public T OriginalMessage { get; }

        public FailedMessage(string originalId, T originalMessage)
        {
            OriginalId = originalId;
            OriginalMessage = originalMessage;
        }
    }
}
