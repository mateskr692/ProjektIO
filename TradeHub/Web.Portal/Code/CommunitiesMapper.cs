using AutoMapper;
using Buisness.Contracts.Models;
using Web.Portal.Models;

namespace Web.Portal.Code
{
    public class CommunitiesMapper
    {
        internal static IMapper Default = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CommunityModel, CommunityViewModel>();
            cfg.CreateMap<CommunityInfoModel, CommunityInfoViewModel>();
            cfg.CreateMap<CommunityIndexModel, CommunityIndexViewModel>();

            cfg.CreateMap<CommunityViewModel, CommunityModel>();
        }).CreateMapper();
    }
}