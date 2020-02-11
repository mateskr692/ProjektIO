using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class ToolPictureFilters : IFiltrable<ToolPictureSorting>
    {
        public ToolPictureSorting SortingColumn { get; set; }
        public SortingOrder Order { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;

        public long? Id { get; set; }
    }
}
