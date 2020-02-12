using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Filters;

namespace Data.DAL
{
    public class OffertRepository : BaseRepository<Offert, OffertFilters, OffertSorting>
    {
        public OffertRepository( DbContext context ) : base( context )
        {
        }

        public override IDictionary<long, string> GetDictionary()
        {
            throw new NotImplementedException();
        }

        public override IDictionary<long, string> GetFilteredDictionary( OffertFilters filters )
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Offert> GetPage( OffertFilters filters )
        {
            IQueryable<Offert> offerts = this.dbSet;
            if( filters != null)
            {
                //Filtering
                if ( filters.ProposedReturn != null)
                {
                    offerts = offerts.Where( it => it.ProposedReturn >= filters.ProposedReturn );
                }
                if( !string.IsNullOrEmpty(filters.Comment))
                {
                    offerts = offerts.Where( it => it.Comment.ToUpper().Contains( filters.Comment.ToUpper() ) );
                }

                //Sorting
                switch ( filters.SortingColumn )
                {
                    case OffertSorting.ProposedReturn:
                        offerts = filters.Order == SortingOrder.Ascending ? offerts.OrderBy( it => it.ProposedReturn ) : offerts.OrderByDescending( it => it.ProposedReturn );
                        break;

                    case OffertSorting.Comment:
                        offerts = filters.Order == SortingOrder.Ascending ? offerts.OrderBy( it => it.Comment ) : offerts.OrderByDescending( it => it.Comment );
                        break;
                }
            }

            //Paginations
            return offerts.Skip( filters.PageSize * ( filters.PageNumber - 1 ) )
                           .Take( filters.PageSize )
                           .AsEnumerable();
        }

        public IEnumerable<Offert> GetSentOfferts(long userId)
        {
            return this.dbSet.Where( m => m.SenderId == userId );
        }

        public IEnumerable<Offert> GetRecievedOfferts( long userId )
        {
            return this.dbSet.Where( m => m.ReceiverId == userId );
        }
    }
}
