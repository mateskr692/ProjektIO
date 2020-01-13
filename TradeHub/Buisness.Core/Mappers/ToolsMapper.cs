using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Buisness.Contracts.Models;
using Data.DAL;

namespace Buisness.Core.Mappers
{
    public class ToolsMapper
    {
        internal static IMapper Default = new MapperConfiguration( cfg =>
        {

            cfg.CreateMap<Tool, ToolModel>()
                .ForMember( m => m.Quality, opt => opt.MapFrom( t => t.Quality ? 1 : 0 ) )
                .ForMember( m => m.Availability, opt => opt.MapFrom( t => t.Availability ? 1 : 0 ) );
            cfg.CreateMap<ToolModel, Tool>()
                .ForMember( m => m.Quality, opt => opt.MapFrom( t => t.Quality != 0 ? 1 : 0 ) )
                .ForMember( m => m.Availability, opt => opt.MapFrom( t => t.Availability != 0 ? 1 : 0 ) );

            cfg.CreateMap<Tool, ToolInfoModel>();
            cfg.CreateMap<ToolInfoModel, Tool>();

        } ).CreateMapper();
    }
}
