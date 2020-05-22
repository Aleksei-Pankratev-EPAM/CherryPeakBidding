using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Data.Contracts.Entities;
using CherryPeakTrading.Data.Contracts.Specifications;
using CherryPeakTrading.Data.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

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
