using AutoMapper;
using Buisness.Contracts.Models;
using Web.Portal.Models;

namespace Web.Portal.Code
{
    public class OffertMapper
    {
        internal static IMapper Default = new MapperConfiguration( cfg =>
        {
            cfg.CreateMap<OffertModel, OffertViewModel>();
            cfg.CreateMap<OffertViewModel, OffertModel>();
            cfg.CreateMap<OffertInfoModel, OffertInfoViewModel>();

            cfg.CreateMap<OffertIndexModel, OffertIndexViewModel>();

        } ).CreateMapper();
    }
}