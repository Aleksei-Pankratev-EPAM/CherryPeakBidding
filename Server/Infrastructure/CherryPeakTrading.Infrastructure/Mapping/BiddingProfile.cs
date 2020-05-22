using AutoMapper;
using CherryPeakTrading.API.Models.ViewModels;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.Data.Contracts.Entities;

namespace CherryPeakTrading.Infrastructure.Mapping
{
    internal class BiddingProfile : Profile
    {
        public BiddingProfile()
        {
            CreateMap<LotViewModel, LotModel>().ForMember(x => x.CreatedAt, opt => opt.Ignore())
                                               .ForMember(x => x.Creator, opt => opt.Ignore())
                                               .ForMember(x => x.Status, opt => opt.Ignore())
                                               .ForMember(x => x.TimeToLive, opt => opt.Ignore());
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
            CreateMap<Lot, LotModel>().ForMember(x => x.TimeToLive, opt => opt.Ignore());
            CreateMap<LotModel, LotViewModel>();
            CreateMap<User, UserModel>();
            CreateMap<Region, RegionModel>();
            CreateMap<PersonalAccount, PersonalAccountModel>();
            CreateMap<UserModel, UserViewModel>();
            CreateMap<RegionModel, RegionViewModel>();
            CreateMap<PersonalAccountModel, PersonalAccountViewModel>();
        }
    }
}
