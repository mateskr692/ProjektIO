using AutoMapper;
using Buisness.Contracts.Models;
using Web.Portal.Models;

namespace Web.Portal.Code
{
    public class TransactionMapper
    {
        internal static IMapper Default = new MapperConfiguration( cfg =>
        {
            cfg.CreateMap<TransactionModel, TransactionViewModel>();
            cfg.CreateMap<TransactionViewModel, TransactionModel>();
            cfg.CreateMap<TransactionInfoModel, TransactionInfoViewModel>();

            cfg.CreateMap<TransactionIndexModel, TransactionIndexViewModel>();

        } ).CreateMapper();
    }
}