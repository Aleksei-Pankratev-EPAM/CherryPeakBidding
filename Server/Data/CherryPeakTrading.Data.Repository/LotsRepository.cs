using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Data.Contracts.Entities;
using CherryPeakTrading.Data.Contracts.Specifications;
using CherryPeakTrading.Data.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CherryPeakTrading.Data.Repository
{
    public class LotsRepository : EFRepository<Lot, BiddingDbContext, LotsSpecification>, ILotRepository
    {
        public LotsRepository(BiddingDbContext context) : base(context)
        {
        }

        public override Task<IList<Lot>> Get(LotsSpecification criteria)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Lot> SaveLot(Lot lot)
        {
            await Add(lot);

            var savedLot = await Get(lot.Id);

            return savedLot;
        }
    }
}
