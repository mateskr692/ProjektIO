using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Buisness.Contracts;
using Buisness.Contracts.Models;
using Buisness.Core.Mappers;
using Common.Enums;
using Data.DAL;

namespace Buisness.Core.Services
{
    //Podzial na UserService i AccountService: User - przegladanie wyswietlanie profili, edytowanie wlasnych pol
    //Account - logowanie, authentyfikacja, zmiana hasel itp
    public class AccountService
    {
        public WResult Register( UserRegisterModel registerModel )
        {
            //add model validation

            using ( var uow = new UnitOfWork() )
            {
                //check if user can be created
                if ( !uow.Users.IsUnique( registerModel.Login, registerModel.Email ) )
                {
                    return new WResult( ValidationStatus.Failed, "User with this Login or Email already exsits" );
                }

                var newUser = UsersMapper.Default.Map<User>( registerModel );
                using ( var sha256 = SHA256.Create() )
                {
                    var salt = new byte[ 4 ];
                    new Random().NextBytes( salt );
                    var hashPassword = sha256.ComputeHash( Encoding.UTF8.GetBytes( registerModel.Password ).Concat( salt ).ToArray() );

                    newUser.Salt = salt;
                    newUser.Password = hashPassword;
                }

                uow.Users.Add( newUser );
                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );

        }

        public WResult<UserModel> Login( UserLoginModel loginModel )
        {
            using ( var uow = new UnitOfWork() )
            {
                var user = uow.Users.GetByLogin( loginModel.Login );
                if ( user == null )
                {
                    return new WResult<UserModel>( ValidationStatus.Failed, "Account does not exist" );
                }

                using ( var sha256 = SHA256.Create() )
                {
                    var hashPassword = sha256.ComputeHash( Encoding.UTF8.GetBytes( loginModel.Password ).Concat( user.Salt ).ToArray() );
                    if ( user.Password.SequenceEqual( hashPassword ) )
                    {
                        return new WResult<UserModel>( ValidationStatus.Succeded, errors: null, UsersMapper.Default.Map<UserModel>( user ) );
                    }

                    return new WResult<UserModel>( ValidationStatus.Failed, "Invalid Password" );
                }
            }
        }
    }
}
