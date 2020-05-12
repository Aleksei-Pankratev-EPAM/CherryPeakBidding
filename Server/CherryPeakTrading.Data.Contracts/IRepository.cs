using System.Collections.Generic;
using System.Threading.Tasks;

namespace CherryPeakTrading.Data.Contracts
{
    public interface IRepository<T, Specification> : IBaseRepository<T> where T : class
                                                                    where Specification : class
    {
        Task<IList<T>> Get(Specification criteria);
    }
}
