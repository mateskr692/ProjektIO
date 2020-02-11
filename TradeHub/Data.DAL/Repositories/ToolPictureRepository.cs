using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Filters;

namespace Data.DAL
{
    public class ToolPictureRepository : BaseRepository<ToolPicture, ToolPictureFilters, ToolPictureSorting>
    {
        public ToolPictureRepository( DbContext context ) : base( context )
        {
        }

        public override IDictionary<long, string> GetDictionary()
        {
            var toolPicturesDictionary = new Dictionary<long, string>();
            foreach ( var picture in this.dbSet )
            {
                toolPicturesDictionary.Add( picture.Id, picture.ToolId.ToString() );
            }

            return toolPicturesDictionary;
        }

        public override IDictionary<long, string> GetFilteredDictionary( ToolPictureFilters filters )
        {
            IQueryable<ToolPicture> toolPictures = this.dbSet;
            var toolPicturesDictionary = new Dictionary<long, string>();

            if( filters != null )
            {
                if ( filters.Id != null )
                {
                    toolPictures = toolPictures.Where( it => it.Id == filters.Id );
                }
            }

            foreach( var picture in toolPictures)
            {
                toolPicturesDictionary.Add( picture.Id, picture.ToolId.ToString() );
            }

            return toolPicturesDictionary;
        }

        public override IEnumerable<ToolPicture> GetPage( ToolPictureFilters filters )
        {
            IQueryable<ToolPicture> toolPictures = this.dbSet;
           
            if ( filters != null )
            {
                //filtering
                if ( filters.Id != null )
                {
                    toolPictures = toolPictures.Where( it => it.Id == filters.Id );
                }

                //sorting
                switch(filters.SortingColumn)
                {
                    case ToolPictureSorting.Id:
                        toolPictures = filters.Order == SortingOrder.Ascending ? toolPictures.OrderBy( it => it.Id ) : toolPictures.OrderByDescending( it => it.Id );
                        break;
                }
            }

            //Paginations
            return toolPictures.Skip( filters.PageSize * ( filters.PageNumber - 1 ) )
                               .Take( filters.PageSize )
                               .AsEnumerable();
        }
    }
}
