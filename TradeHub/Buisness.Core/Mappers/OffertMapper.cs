using AutoMapper;
using Buisness.Contracts.Models;
using Data.DAL;

namespace Buisness.Core.Mappers
{
    class OffertMapper
    {
        public static IMapper Default = new MapperConfiguration( cfg =>
        {
            cfg.CreateMap<Offert, OffertModel>();
            cfg.CreateMap<Offert, OffertInfoModel>()
                .ForMember( it => it.SenderName, opt => opt.MapFrom( src => src.Sender.Login ) )
                .ForMember( it => it.RecieverName, opt => opt.MapFrom( src => src.Receiver.Login ) )
                .ForMember( it => it.ReceiverToolName, opt => opt.MapFrom( src => src.ReceiverTool.Name ) )
                .ForMember( it => it.SenderToolName, opt => opt.MapFrom( src => src.SenderId == null ? "" : src.SenderTool.Name ) );

            cfg.CreateMap<OffertModel, Offert>();

        } ).CreateMapper();
    }
}
