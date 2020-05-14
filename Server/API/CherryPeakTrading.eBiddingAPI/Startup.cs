using CherryPeakTrading.DI;
using CherryPeakTrading.DI.Logging;
using CherryPeakTrading.DI.Messaging;
using CherryPeakTrading.Infrastructure.Contracts.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace CherryPeakTrading.eBidding
{
    public class Startup
    {
        private const string ApiVersion = "v1";
        private const string ApiName = "Bidding API";

        private const string MessagingSectionKey = "Messaging";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDependencies(services);
            services.AddControllers();
            services.AddSingleton(sp => { return CloudStorageAccount.Parse(Configuration.GetConnectionString("BlobAccessKey")).CreateCloudBlobClient(); });

            var esConnectionString = Configuration.GetConnectionString("ElasticSearch");
            services.AddStructuredLogging(esConnectionString);

            var messagingConfiguration = Configuration.GetSection(MessagingSectionKey)?.Get<MessagingConfiguration>()
                                         ?? new MessagingConfiguration();
            services.AddMessaging(messagingConfiguration);
            services.AddMessagePublishing();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new OpenApiInfo { Title = ApiName, Version = ApiVersion });
            });
         }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", $"{ApiName} {ApiVersion}");
            });
        }

        protected void RegisterDependencies(IServiceCollection services)
        {
            services.ConfigureBidding(Configuration);
        }
    }
}
