using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class RequestFilters : IFiltrable<RequestSorting>
    {
        public RequestSorting SortingColumn { get; set; }
        public SortingOrder Order { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
