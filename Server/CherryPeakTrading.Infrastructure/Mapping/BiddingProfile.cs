using AutoMapper;
using CherryPeakTrading.API.ViewModels;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.Data.EF.Entities;

namespace CherryPeakTrading.Infrastructure.Mapping
{
    internal class BiddingProfile : Profile
    {
        public BiddingProfile()
        {
            CreateMap<LotsFilterViewModel, LotModel>();
            CreateMap<LotModel, Lot>();
        }
    }
}
