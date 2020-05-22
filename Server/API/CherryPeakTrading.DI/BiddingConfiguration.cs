using CherryPeakTrading.BL;
using CherryPeakTrading.BL.Contracts;
using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Data.Contracts.Specifications;
using CherryPeakTrading.Data.EF;
using CherryPeakTrading.Data.EF.Entities;
using CherryPeakTrading.Data.Repository;
using CherryPeakTrading.Infrastructure.Contracts;
using CherryPeakTrading.Infrastructure.FileStorage;
using CherryPeakTrading.Infrastructure.Mapping;
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

            services.AddSingleton<IMapperAdapter, BiddingMapperAdapter>();
            services.AddScoped<ILotRepository, LotsRepository>();
            services.AddScoped<ILotsLogic, LotsLogic>();
            services.AddTransient<IFileStorage, BlobStorage>();
            services.AddTransient<IPhotosLogic, PhotosLogic>();
            services.AddTransient<IRepository<Photo, PhotosSpecification>, PhotosRepository>();
        }
    }
}
