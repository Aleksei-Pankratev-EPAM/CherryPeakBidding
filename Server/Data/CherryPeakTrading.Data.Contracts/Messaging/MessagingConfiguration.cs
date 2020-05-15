namespace CherryPeakTrading.Data.Contracts.Messaging
{
    /// <summary>
    /// Parameters for connection to the message queue broker.
    /// </summary>
    public class MessagingConfiguration
    {
        public string UserName { get; set; } = "guest";

        public string Password { get; set; } = "guest";

        public string HostName { get; set; } = "localhost";

        public int Port { get; set; } = 5672;

        public string VirtualHost { get; set; } = "/";
    }
}
