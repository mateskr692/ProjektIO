using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class CommunityFilters : IFiltrable<CommunitySorting>
    {
        public CommunitySorting SortingColumn { get; set; }
        public SortingOrder Order { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
