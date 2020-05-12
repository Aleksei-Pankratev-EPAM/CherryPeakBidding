using CherryPeakTrading.Data.EF;
using CherryPeakTrading.Data.EF.Entities;
using CherryPeakTrading.Data.Repository.Specifications;

namespace CherryPeakTrading.Data.Repository
{
    public class LotsRepository : EFRepository<Lot, BiddingDbContext, LotsSpecification>
    {
        public LotsRepository(BiddingDbContext context) : base(context)
        {
        }
    }
}
