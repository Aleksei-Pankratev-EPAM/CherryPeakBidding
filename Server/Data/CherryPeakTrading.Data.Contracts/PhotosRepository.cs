using CherryPeakTrading.Data.EF;
using CherryPeakTrading.Data.EF.Entities;
using CherryPeakTrading.Data.Specifications;

namespace CherryPeakTrading.Data.Repository
{
    public class PhotosRepository : EFRepository<Photo, BiddingDbContext, PhotosSpecification>
    {
        public PhotosRepository(BiddingDbContext context) : base(context)
        {
        }
    }
}
