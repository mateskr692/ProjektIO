using AutoMapper;
using Buisness.Contracts.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Core.Mappers
{
    public class CommunitiesMapper
    {
        // pewnie nie powinno byc public, ale w CommunitiesControllerze się pluło, że jest inaccessible
        public static IMapper Default = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CommunityModel, Community>();
            cfg.CreateMap<Community, CommunityModel>();
            cfg.CreateMap<Community, CommunityInfoModel>();

            cfg.CreateMap<CommunityModel, CommunityIndexModel>();
            cfg.CreateMap<CommunityModel, CommunityInfoModel>();
        }).CreateMapper();
    }
}
