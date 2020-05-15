using AutoMapper;
using CherryPeakTrading.API.Models.ViewModels;
using CherryPeakTrading.BL;
using CherryPeakTrading.BL.Contracts;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Data.Contracts.Entities;
using CherryPeakTrading.Data.Repository;

namespace CherryPeakTrading.Infrastructure.Mapping
{
    internal class BiddingProfile : Profile
    {
        public BiddingProfile()
        {
            CreateMap<LotsFilterViewModel, LotModel>();
            CreateMap<PhotoViewModel, PhotoModel>();
            CreateMap<BidViewModel, BidModel>();
            CreateMap<UserViewModel, UserModel>();
            CreateMap<RegionViewModel, RegionModel>();
            CreateMap<PersonalAccountViewModel, PersonalAccountModel>();
            CreateMap<LotModel, Lot>().ForMember(x => x.Photos, opt => opt.Ignore())
                                       .ForMember(x => x.CreatorId, opt => opt.Ignore())
                                       .ForMember(x => x.Bids, opt => opt.Ignore());
            CreateMap<PhotoModel, Photo>();
            CreateMap<BidModel, Bid>();
            CreateMap<UserModel, User>();
            CreateMap<RegionModel, Region>();
            CreateMap<PersonalAccountModel, PersonalAccount>();
            CreateMap<Lot, LotModel>();
            CreateMap<LotModel, LotsFilterViewModel>();
            CreateMap<User, UserModel>();
            CreateMap<Region, RegionModel>();
            CreateMap<PersonalAccount, PersonalAccountModel>();
            CreateMap<UserModel, UserViewModel>();
            CreateMap<RegionModel, RegionViewModel>();
            CreateMap<PersonalAccountModel, PersonalAccountViewModel>();
        }
    }
}
