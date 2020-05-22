using CherryPeakTrading.Data.Contracts.Specifications;
using CherryPeakTrading.Data.EF;
using CherryPeakTrading.Data.EF.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CherryPeakTrading.Data.Repository
{
    public class PhotosRepository : EFRepository<Photo, BiddingDbContext, PhotosSpecification>
    {
        public PhotosRepository(BiddingDbContext context) : base(context)
        {
        }

        public override Task<IList<Photo>> Get(PhotosSpecification criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
