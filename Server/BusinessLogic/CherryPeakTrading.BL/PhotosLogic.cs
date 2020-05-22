using CherryPeakTrading.BL.Contracts;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Data.Contracts.Specifications;
using CherryPeakTrading.Data.EF.Entities;
using CherryPeakTrading.Infrastructure.Contracts;
using System.Threading.Tasks;

namespace CherryPeakTrading.BL
{
    public class PhotosLogic : IPhotosLogic
    {
        private readonly IRepository<Photo, PhotosSpecification> _photosRepository;
        private readonly IMapperAdapter _mapperAdapter;

        public PhotosLogic(IMapperAdapter mapperAdapter, IRepository<Photo, PhotosSpecification> photosRepository)
        {
            _mapperAdapter = mapperAdapter;
            _photosRepository = photosRepository;
        }

        public Task AddPhoto(PhotoModel domainPhoto)
        {
            Photo photo = _mapperAdapter.Map<Photo>(domainPhoto);
            return _photosRepository.Add(photo);
        }
    }
}
