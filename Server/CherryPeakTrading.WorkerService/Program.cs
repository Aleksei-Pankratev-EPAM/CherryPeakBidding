using CherryPeakTrading.DI.Logging;
using CherryPeakTrading.DI.Messaging;
using CherryPeakTrading.Infrastructure.Contracts.Messaging;
using CherryPeakTrading.WorkerService.Consumers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CherryPeakTrading.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var esConnectionString = hostContext.Configuration.GetConnectionString("ElasticSearch");
                    services.AddStructuredLogging(esConnectionString);

                    var messagingSection = hostContext.Configuration.GetSection("Messaging");
                    var messagingConfiguration = messagingSection?.Get<MessagingConfiguration>()
                                                 ?? new MessagingConfiguration();

                    services.AddMessaging(messagingConfiguration);
                    services.AddMessagePublishing();
                    services.AddMessageConsumer<LotCreatedConsumer>();
                    services.AddMessageConsumer<BidCreatedConsumer>();

                    services.AddHostedService<Worker>();
                });
    }
}
