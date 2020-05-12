using CherryPeakTrading.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CherryPeakTrading.DI
{
    public static class BiddingConfiguration
    {
        private const string BiddingDBConnectionString = "BiddingDB";

        public static void ConfigureBidding(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BiddingDbContext>(opts => opts.UseNpgsql(configuration.GetConnectionString(BiddingDBConnectionString)));
        }
    }
}
