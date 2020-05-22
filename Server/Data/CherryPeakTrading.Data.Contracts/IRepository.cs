using System.Collections.Generic;
using System.Threading.Tasks;

namespace CherryPeakTrading.Data.Contracts
{
    public interface IRepository<TEntity, TSpecification> : IBaseRepository<TEntity>
        where TEntity : class
        where TSpecification : ISpecification<TEntity>
    {
        Task<IList<TEntity>> Get(TSpecification criteria);
    }
}
