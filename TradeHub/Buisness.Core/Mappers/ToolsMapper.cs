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
 
            cfg.CreateMap<Tool, ToolModel>();
            cfg.CreateMap<Tool, ToolInfoModel>();

        } ).CreateMapper();
    }
}
