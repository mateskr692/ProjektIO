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
    public class RequestMapper
    {
        public static IMapper Default = new MapperConfiguration( cfg =>
        {
            cfg.CreateMap<Request, RequestModel>();
            cfg.CreateMap<Request, RequestInfoModel>()
                .ForMember( it => it.UserName, opt => opt.MapFrom( src => src.User.Login ) )
                .ForMember( it => it.CommunityName, opt => opt.MapFrom( src => src.Community.Name ) );


        } ).CreateMapper();
    }
}
