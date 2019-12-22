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
    public class ToolRepository : BaseRepository<Tool, ToolFilters, ToolSorting>
    {
        public ToolRepository( DbContext context ) : base( context )
        {
        }


        public override IDictionary<long, string> GetDictionary()
        {
            var toolsDictionary = new Dictionary<long, string>();
            foreach ( var tool in this.dbSet )
            {
                toolsDictionary.Add( tool.Id, tool.Name );
            }

            return toolsDictionary;

        }


        public override IDictionary<long, string> GetFilteredDictionary( ToolFilters filters )
        {
            IQueryable<Tool> tools = this.dbSet;
            var messagesDictionary = new Dictionary<long, string>();

            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Name ) )
                {
                    tools = tools.Where( it => it.Name.ToUpper().Contains( filters.Name.ToUpper() ) );
                }
                if ( filters.Quality == false)
                {
                    tools = tools.Where( it => it.Quality != filters.Quality );
                }
                if (filters.Quality == false)
                {
                    tools = tools.Where(it => it.Quality != filters.Quality);
                }
                if (filters.Visibility != 0)
                {
                    tools = tools.Where(it => it.Visibility > filters.Visibility);
                }
            }
            
            foreach ( var tool in tools )
            {
                messagesDictionary.Add( tool.Id, tool.Name );
            }

            return messagesDictionary;
        }


        public override IEnumerable<Tool> GetPage( ToolFilters filters )
        {
            IQueryable<Tool> tools = this.dbSet;

            if ( filters != null )
            {
                //Filtering
                if (!string.IsNullOrEmpty(filters.Name))
                {
                    tools = tools.Where(it => it.Name.ToUpper().Contains(filters.Name.ToUpper()));
                }
                if (filters.Quality == false)
                {
                    tools = tools.Where(it => it.Quality != filters.Quality);
                }
                if (filters.Quality == false)
                {
                    tools = tools.Where(it => it.Quality != filters.Quality);
                }
                if (filters.Visibility != 0)
                {
                    tools = tools.Where(it => it.Visibility > filters.Visibility);
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
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy(it => it.Availability) : tools.OrderByDescending(it => it.Availability);
                        break;
                }
            }

            //Paginations
            return tools.Skip( filters.PageSize * ( filters.PageNumber - 1 ) )
                           .Take( filters.PageSize )
                           .AsEnumerable();
        }

        public IEnumerable<Tool> GetUserPage(ToolFilters filters, long userId)
        {
            IQueryable<Tool> tools = this.dbSet;

            //tools = tools.Where(it => it.Id == userId);

            

            if (filters != null)
            {
           
                /*
                //Filtering

                if (!string.IsNullOrEmpty(filters.Name))
                {
                    tools = tools.Where(it => it.Name.ToUpper().Contains(filters.Name.ToUpper()));
                }
                if (filters.Quality == false)
                {
                    tools = tools.Where(it => it.Quality != filters.Quality);
                }
                if (filters.Quality == false)
                {
                    tools = tools.Where(it => it.Quality != filters.Quality);
                }
                if (filters.Visibility != 0)
                {
                    tools = tools.Where(it => it.Visibility > filters.Visibility);
                }
                */
                

                //Sorting
                switch (filters.SortingColumn)
                {
                    case ToolSorting.Name:
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy(it => it.Name) : tools.OrderByDescending(it => it.Name);
                        break;

                    case ToolSorting.Quality:
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy(it => it.Quality) : tools.OrderByDescending(it => it.Quality);
                        break;

                    case ToolSorting.Visibility:
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy(it => it.Visibility) : tools.OrderByDescending(it => it.Visibility);
                        break;

                    case ToolSorting.Availability:
                        tools = filters.Order == SortingOrder.Ascending ? tools.OrderBy(it => it.Availability) : tools.OrderByDescending(it => it.Availability);
                        break;
                }
            }

            //Paginations
            return tools.Skip(filters.PageSize * (filters.PageNumber - 1))
                           .Take(filters.PageSize)
                           .AsEnumerable();
        }
    }
}
