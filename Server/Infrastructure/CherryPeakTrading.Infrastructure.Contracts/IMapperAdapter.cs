﻿namespace CherryPeakTrading.Infrastructure.Contracts
{
    public interface IMapperAdapter
    {
        TDestination Map<TDestination>(object source)
            where TDestination : class;

        TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class;
    }
}
