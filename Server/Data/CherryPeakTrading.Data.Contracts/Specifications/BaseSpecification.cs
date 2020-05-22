using CherryPeakTrading.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CherryPeakTrading.Data.Contracts.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Predicate<T>> Criteria { get; set; } = _ => false;
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}
