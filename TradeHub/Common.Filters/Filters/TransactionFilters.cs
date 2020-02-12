using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class TransactionFilters : IFiltrable<TransactionSorting>
    {
        public TransactionSorting SortingColumn { get; set; }
        public SortingOrder Order { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string LenderName { get; set; }
        public string BorrowerName { get; set; }
        public string LenderToolName { get; set; }
        public string BorrowerToolName { get; set; }
    }
}
