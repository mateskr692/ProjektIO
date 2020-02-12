using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class OffertFilters : IFiltrable<OffertSorting>
    {
        public OffertSorting SortingColumn { get; set; }
        public SortingOrder Order { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public DateTime? ProposedReturn { get; set; }
        public string Comment { get; set; }
    }
}
