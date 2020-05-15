using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.RollingFile;
using System;

namespace CherryPeakTrading.Infrastructure.Logging
{
    internal class SerilogLoggerFactory
    {
        private readonly Uri _esUri;

        public SerilogLoggerFactory(string esConnectionString)
        {
            _esUri = new Uri(esConnectionString);
        }

        public ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .Enrich.FromLogContext()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(_esUri)
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
