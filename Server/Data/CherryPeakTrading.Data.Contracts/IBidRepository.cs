using CherryPeakTrading.Data.Contracts.Entities;
using CherryPeakTrading.Data.Contracts.Specifications;

namespace CherryPeakTrading.Data.Contracts
{
    public interface IBidRepository : IRepository<Bid, BidsSpecification>
    {
    }
}
