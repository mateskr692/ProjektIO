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
using Common.Filters;
using Data.DAL;

namespace Buisness.Core.Services
{
    public class UserService
    {
        private static readonly string UserNotExistsMessage = "User with given Id does not exist";

        //TODO dodac walidacje otzrymywanego modelu przed wykonaniem serwisu

        //wejscie na strone Index wyswietli wszystkich uzytkownikow i pozwoli  ich sortowac filtrowac i kilknac w guzik zobacz...
        public WResult<UserIndexModel> GetPaged( UserFilters filters )
        {
            using ( var uow = new UnitOfWork() )
            {
                var users = uow.Users.GetPage( filters );

                var userPage = new UserIndexModel()
                {
                    Users = UsersMapper.Default.Map<List<UserInfoModel>>( users ),
                    Filters = filters
                };

                uow.Complete();
                return new WResult<UserIndexModel>( ValidationStatus.Succeded, errors: null, userPage );
            }
        }

        //... ktory pokaze strone domowa uzytkownika
        public WResult<UserModel> GetById(long id)
        {
            using ( var uow = new UnitOfWork() )
            {
                var user = uow.Users.GetById( id );
                if( user == null )
                {
                    return new WResult<UserModel>( ValidationStatus.Failed, UserNotExistsMessage );
                }

                var userModel = UsersMapper.Default.Map<UserModel>( user );
                uow.Complete();
                return new WResult<UserModel>( ValidationStatus.Succeded, errors: null, userModel );
            }
        }

        //bedac na wlasnej stronie (albo klikajac gdzies z panelu) mozna edytowac swoje konto (zmieniac pola widocznosci, 
        //dodawanie narzedzi prawdopodobnie zamkniemy w ToolService i ToolModel bedzie zawieral jedynie Id uzytkonika
        public WResult Update( UserModel userModel )
        {
            using ( var uow = new UnitOfWork() )
            {
                var user = uow.Users.GetById( userModel.Id );
                if ( user == null)
                {
                    return new WResult( ValidationStatus.Failed, UserNotExistsMessage );
                }

                //zamiast robic user = ...Map(userModel) zamapaujmy na obiekty ktory juz wyciangelismy
                //dzieki temu entity frameowrk widzi ze to caly czas ten sam obiekt i zmienily mus sie pola
                //w skrocie, inaczej moze nie dzialac
                UsersMapper.Default.Map( userModel, user );

                uow.Complete();
                return new WResult( ValidationStatus.Succeded );
            }
        }

        public WResult UpdateUserInfo( UserModel userModel )
        {
            using ( var uow = new UnitOfWork() )
            {
                var user = uow.Users.GetById( userModel.Id );
                if ( user == null )
                {
                    return new WResult( ValidationStatus.Failed, UserNotExistsMessage );
                }

                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.NameVisibility = (int)userModel.NameVisibility;

                user.Contact = userModel.Contact;
                user.ContactVisibility = (int)userModel.ContactVisibility;

                user.Address = userModel.Address;
                user.AdressVisibility = (int)userModel.AdressVisibility;

                uow.Complete();
                return new WResult( ValidationStatus.Succeded );
            }
        }

        public WResult<UserIndexModel> GetCommunityUsers( UserFilters filters, long communityId )
        {
            using ( var uow = new UnitOfWork() )
            {
                var users = uow.Communities.GetCommunityUsers( filters, communityId );

                var userPage = new UserIndexModel()
                {
                    Users = UsersMapper.Default.Map<List<UserInfoModel>>( users ),
                    Filters = filters
                };

                uow.Complete();
                return new WResult<UserIndexModel>( ValidationStatus.Succeded, errors: null, userPage );
            }
        }

        

    }
}
