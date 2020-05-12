using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.RollingFile;
using System;
using System.IO;

namespace CherryPeakTrading.eBidding
{
    public class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", true, true)
                           .AddEnvironmentVariables()
               .Build();

        public static void Main(string[] args)
        {
            CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                  .Enrich.WithMachineName()
                  .Enrich.WithEnvironmentUserName()
                  .Enrich.FromLogContext()
                  .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Configuration.GetConnectionString("ElasticSearch")))
                  {
                      // Write a default template to Elasticsearch
                      AutoRegisterTemplate = true,
                      AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                      // Serialize any exception into an exception object
                      CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true),
                      // Handle issues with Elasticsearch
                      FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                      EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                       EmitEventFailureHandling.WriteToFailureSink |
                                       EmitEventFailureHandling.RaiseCallback,
                      FailureSink = new RollingFileSink("./failureSink.txt", new JsonFormatter(), null, null)
                  })
                  .CreateLogger();
        }
    }
}
