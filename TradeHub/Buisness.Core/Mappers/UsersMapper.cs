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
    public class UsersMapper
    {
        internal static IMapper Default = new MapperConfiguration( cfg =>
        {
            //           source  destination
            cfg.CreateMap<User, UserModel>();
            cfg.CreateMap<User, UserInfoModel>();
            cfg.CreateMap<UserRegisterModel, User>()
                //.ForMember( m => m.NameVisibility, opt => opt.MapFrom( u => (int)u.NameVisibility ) )
                //.ForMember( m => m.ContactVisibility, opt => opt.MapFrom( u => (int)u.ContactVisibility ) )
                //.ForMember( m => m.AdressVisibility, opt => opt.MapFrom( u => (int)u.AdressVisibility ) );
                .ForMember( m => m.Password, opt => opt.Ignore() );
        } ).CreateMapper();
    }
}
