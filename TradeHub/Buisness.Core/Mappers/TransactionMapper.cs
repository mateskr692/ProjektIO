using AutoMapper;
using Buisness.Contracts.Models;
using Data.DAL;

namespace Buisness.Core.Mappers
{
    public class TransactionMapper
    {
        public static IMapper Default = new MapperConfiguration( cfg =>
        {
            cfg.CreateMap<Transaction, TransactionModel>();
            cfg.CreateMap<Transaction, TransactionInfoModel>()
                .ForMember( it => it.BorowerName, opt => opt.MapFrom( src => src.Borower.Login ) )
                .ForMember( it => it.LenderName, opt => opt.MapFrom( src => src.Lender.Login ) )
                .ForMember( it => it.BorowerToolName, opt => opt.MapFrom( src => src.BorrowerTool.Name ) )
                .ForMember( it => it.LenderToolName, opt => opt.MapFrom( src => src.LenderToolId == null ? "" : src.SenderTool.Name ) );

            cfg.CreateMap<TransactionModel, Transaction>();

        } ).CreateMapper();
    }
}
