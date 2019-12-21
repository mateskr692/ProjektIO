using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Filters;

namespace Data.DAL
{
    public class UserRepository : BaseRepository<User, UserFilters, UserSorting>
    {
        public UserRepository( DbContext context ) : base( context )
        {
        }

        #region Interface Implementation

        public override IDictionary<long, string> GetDictionary()
        {
            var usersDictionary = new Dictionary<long, string>();
            foreach ( var user in this.dbSet )
            {
                usersDictionary.Add( user.Id, user.Login );
            }

            return usersDictionary;
        }

        public override IDictionary<long, string> GetFilteredDictionary( UserFilters filters )
        {
            IQueryable<User> users = this.dbSet;
            var usersDictionary = new Dictionary<long, string>();

            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Login ) )
                {
                    users = users.Where( it => it.Login.ToUpper().Contains( filters.Login.ToUpper() ) );
                }

            }

            foreach ( var user in users )
            {
                usersDictionary.Add( user.Id, user.Login );
            }

            return usersDictionary;
        }

        public override IEnumerable<User> GetPage( UserFilters filters )
        {
            IQueryable<User> users = this.dbSet;

            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Login ) )
                {
                    //fajna skladnia ale nie dziala dla EF
                    //users = users.Where( it => it.Login.Like( filters.Login ) );
                    users = users.Where( it => it.Login.ToUpper().Contains( filters.Login.ToUpper() ) );

                }

                //Sorting
                switch ( filters.SortingColumn )
                {
                    case UserSorting.Login:
                        users = filters.Order == SortingOrder.Ascending ? users.OrderBy( it => it.Login ) : users.OrderByDescending( it => it.Login );
                        break;

                }
            }

            //Paginations
            return users.Skip( filters.PageSize * ( filters.PageNumber - 1 ) )
                           .Take( filters.PageSize )
                           .AsEnumerable();
        }

        #endregion

        #region Additional Methods

        public User GetByLogin(string login)
        {
            return this.dbSet.Where( it => it.Login == login )
                             .SingleOrDefault();
        }

        #endregion

    }
}
