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
            cfg.CreateMap<UserRegisterModel, User>();

        } ).CreateMapper();
    }
}
