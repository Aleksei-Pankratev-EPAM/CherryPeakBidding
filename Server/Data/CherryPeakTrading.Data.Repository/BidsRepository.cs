using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Data.EF;
using CherryPeakTrading.Data.Contracts.Entities;
using CherryPeakTrading.Data.Contracts.Specifications;

namespace CherryPeakTrading.Data.Repository
{
    public class BidsRepository : EFRepository<Bid, BiddingDbContext, BidsSpecification>, IBidRepository
    {
        public BidsRepository(BiddingDbContext context) : base(context)
        {
        }
    }
}
