using AutoMapper;
using CherryPeakTrading.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherryPeakTrading.Infrastructure.Mapping
{
	public class BiddingMapperAdapter : IMapperAdapter
	{
        public BiddingMapperAdapter()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<BiddingProfile>();
            });

            mapperConfiguration.AssertConfigurationIsValid();

            Mapper = mapperConfiguration.CreateMapper();
        }

        protected IMapper Mapper { get; }

        public TDestination Map<TDestination>(object source)
            where TDestination : class
                => Mapper.Map<TDestination>(source);

        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
                => Mapper.Map<TSource, TDestination>(source);
    }
}
