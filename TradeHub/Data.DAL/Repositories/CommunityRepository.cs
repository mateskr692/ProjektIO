using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                    communities = communities.Where( it => it.Name.ToUpper().Contains( filters.Name.ToUpper() ) );
                }
                if ( !string.IsNullOrEmpty( filters.Location ) )
                {
                    communities = communities.Where( it => it.Location.ToUpper().Contains( filters.Location.ToUpper() ) );
                }
                if ( !string.IsNullOrEmpty( filters.Description ) )
                {
                    communities = communities.Where( it => it.Description.ToUpper().Contains( filters.Description.ToUpper() ) );
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
                    communities = communities.Where( it => it.Name.ToUpper().Contains( filters.Name.ToUpper() ) );
                }
                if ( !string.IsNullOrEmpty( filters.Location ) )
                {
                    communities = communities.Where( it => it.Location.ToUpper().Contains( filters.Location.ToUpper() ) );
                }
                if ( !string.IsNullOrEmpty( filters.Description ) )
                {
                    communities = communities.Where( it => it.Description.ToUpper().Contains( filters.Description.ToUpper() ) );
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


        public bool IsUserInCommunity(long CommunityId, long UserId)
        {
            var Community = this.dbSet.SingleOrDefault(it => it.Id == CommunityId);
            if (Community == null) { return false; }
            
            var CommunityUser = Community.CommunityUsers.SingleOrDefault(it => it.Id == UserId);
            if (CommunityUser == null) { return false; }

            return true;
        }

        public IEnumerable<Tool> GetCommunityTools( ToolFilters filters, long communityId )
        {
            var community = this.dbSet.Where( it => it.Id == communityId ).SingleOrDefault();
            if ( community == null )
                return null;

            var tools = community?.CommunityUsers
                                  .SelectMany( it => it.Tools )
                                  .Where( it => !it.BannedCommunities.Contains( community ) );

            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Name ) )
                {
                    tools = tools.Where( it => it.Name.ToUpper().Contains( filters.Name.ToUpper() ) );
                }
                if ( filters.Quality != null )
                {
                    tools = tools.Where( it => it.Quality == filters.Quality.Value );
                }
                if ( filters.Availability != null )
                {
                    tools = tools.Where( it => it.Availability == filters.Availability.Value );
                }
                if ( filters.Visibility != null )
                {
                    tools = tools.Where( it => it.Visibility == filters.Visibility.Value );
                }

                //Sorting
                switch ( filters.SortingColumn )
                {
                    case ToolSorting.Name:
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy( it => it.Name ) : tools.OrderByDescending( it => it.Name );
                        break;

                    case ToolSorting.Quality:
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy( it => it.Quality ) : tools.OrderByDescending( it => it.Quality );
                        break;

                    case ToolSorting.Visibility:
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy( it => it.Visibility ) : tools.OrderByDescending( it => it.Visibility );
                        break;

                    case ToolSorting.Availability:
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy( it => it.Availability ) : tools.OrderByDescending( it => it.Availability );
                        break;
                }
            }
            return tools.Skip( filters.PageSize * ( filters.PageNumber - 1 ) )
                        .Take( filters.PageSize )
                        .AsEnumerable();
        }

        public IEnumerable<User> GetCommunityUsers( UserFilters filters, long communityId )
        {
            var community = this.dbSet.Where( it => it.Id == communityId ).SingleOrDefault();
            if ( community == null )
                return null;

            var users = community.CommunityUsers.AsQueryable();
            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Login ) )
                {
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

            return users.Skip( filters.PageSize * ( filters.PageNumber - 1 ) )
                        .Take( filters.PageSize )
                        .AsEnumerable();
        }
    }
}
