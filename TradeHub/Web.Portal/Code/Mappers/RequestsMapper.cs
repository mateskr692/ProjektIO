using AutoMapper;
using Buisness.Contracts.Models;
using Web.Portal.Models;


namespace Web.Portal.Code
{
    public class RequestsMapper
    {
        internal static IMapper Default = new MapperConfiguration( cfg =>
        {
            cfg.CreateMap<RequestInfoModel, RequestInfoViewModel>();
            cfg.CreateMap<RequestIndexModel, RequestIndexViewModel>();

        } ).CreateMapper();
    }
}