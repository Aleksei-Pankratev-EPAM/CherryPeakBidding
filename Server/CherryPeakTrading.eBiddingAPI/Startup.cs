using CherryPeakTrading.DI;
using CherryPeakTrading.Data.Contracts.Messaging;
using CherryPeakTrading.DI.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CherryPeakTrading.eBidding
{
    public class Startup
    {
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

            var messagingConfiguration = Configuration.GetSection(MessagingSectionKey)?.Get<MessagingConfiguration>()
                                         ?? new MessagingConfiguration();
            services.AddMessaging(messagingConfiguration);
            services.AddMessagePublishing();
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
        }

        protected void RegisterDependencies(IServiceCollection services)
        {
            services.ConfigureBidding(Configuration);
        }
    }
}
