using Common.Enums;
using Common.Filters;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DAL.Repositories
{
    internal abstract class BaseRepository<TModel, TFilters, TSorting> 
        where TModel : class
        where TFilters : class, ISortable<TSorting>
        where TSorting : Enum
    {
        #region Private Fields

        protected readonly DbSet<TModel> dbSet;
        protected readonly DbContext context;

        #endregion

        #region Ctors

        public BaseRepository( DbContext context )
        {
            this.context = context;
            this.dbSet = context.Set<TModel>();
        }

        #endregion

        #region Abstract Methods

        public abstract IEnumerable<TModel> GetPage( int pageSize, int pageNumber, TFilters filters );

        #endregion

        #region Public Methods

        public void Add( TModel entity )
        {
            this.dbSet.Add( entity );
        }

        public void AddRange( IEnumerable<TModel> entities )
        {
            this.dbSet.AddRange( entities );
        }

        public TModel GetId(long Id)
        {
            return this.dbSet.Find( Id );
        }

        public void Remove( TModel entity )
        {
            this.dbSet.Remove( entity );
        }

        public void RemoveRange( IEnumerable<TModel> entities )
        {
            this.dbSet.RemoveRange( entities );
        }

        #endregion
    }
}
