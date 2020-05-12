using CherryPeakTrading.Data.EF;
using CherryPeakTrading.Data.EF.Entities;
using CherryPeakTrading.Data.Repository.Specifications;

namespace CherryPeakTrading.Data.Repository
{
    public class BidsRepository : EFRepository<Bid, BiddingDbContext, BidsSpecification>
    {
        public BidsRepository(BiddingDbContext context) : base(context)
        {
        }
    }
}
