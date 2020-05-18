using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Data.EF;
using CherryPeakTrading.Data.Contracts.Entities;
using CherryPeakTrading.Data.Contracts.Specifications;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CherryPeakTrading.Data.Repository
{
    public class BidsRepository : EFRepository<Bid, BiddingDbContext, BidsSpecification>, IBidRepository
    {
        public BidsRepository(BiddingDbContext context) : base(context)
        {
        }

        public override Task<IList<Bid>> Get(BidsSpecification criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
