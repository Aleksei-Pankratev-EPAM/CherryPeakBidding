using CherryPeakTrading.Data.Contracts.Entities;
using CherryPeakTrading.Data.Contracts.Specifications;

namespace CherryPeakTrading.Data.Contracts
{
    public interface ILotRepository : IRepository<Lot, LotsSpecification>
    {
    }
}
