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
    public class CommunityRepository : BaseRepository<Community, CommunityFilters, CommunitySorting>
    {
        public CommunityRepository( DbContext context ) : base( context )
        {
        }


        public override IDictionary<long, string> GetDictionary()
        {
            var communitiesDictionary = new Dictionary<long, string>();
            foreach ( var community in this.dbSet )
            {
                communitiesDictionary.Add( community.Id, community.Name );
            }

            return communitiesDictionary;
        }


        public override IDictionary<long, string> GetFilteredDictionary( CommunityFilters filters )
        {
            IQueryable<Community> communities = this.dbSet;
            var communitiesDictionary = new Dictionary<long, string>();

            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Name ) )
                {
                    communities = communities.Where( it => it.Name.Like( filters.Name ) );
                }
                if ( !string.IsNullOrEmpty( filters.Location ) )
                {
                    communities = communities.Where( it => it.Location.Like( filters.Location ) );
                }
                if ( !string.IsNullOrEmpty( filters.Description ) )
                {
                    communities = communities.Where( it => it.Description.Like( filters.Description ) );
                }
            }

            foreach( var community in communities )
            {
                communitiesDictionary.Add( community.Id, community.Name );
            }

            return communitiesDictionary;
        }


        public override IEnumerable<Community> GetPage( CommunityFilters filters )
        {
            IQueryable<Community> communities = this.dbSet;

            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Name ) )
                {
                    communities = communities.Where( it => it.Name.Like( filters.Name ) );
                }
                if ( !string.IsNullOrEmpty( filters.Location ) )
                {
                    communities = communities.Where( it => it.Location.Like( filters.Location ) );
                }
                if ( !string.IsNullOrEmpty( filters.Description ) )
                {
                    communities = communities.Where( it => it.Description.Like( filters.Description ) );
                }

                //Sorting
                switch ( filters.SortingColumn )
                {
                    case CommunitySorting.Name:
                        communities = filters.Order == SortingOrder.Ascending ? communities.OrderBy( it => it.Name ) : communities.OrderByDescending( it => it.Name );
                        break;

                    case CommunitySorting.Location:
                        communities = filters.Order == SortingOrder.Ascending ? communities.OrderBy( it => it.Location ) : communities.OrderByDescending( it => it.Location );
                        break;
                }
            }

            //Pagination
            return communities.Skip( filters.PageSize * ( filters.PageNumber - 1 ) )
                              .Take( filters.PageSize )
                              .AsEnumerable();
        }   
    }
}
