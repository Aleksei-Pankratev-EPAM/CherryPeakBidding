using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CherryPeakTrading.Data.Contracts
{
    public interface ISpecification<T>
    {
        Expression<Predicate<T>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
