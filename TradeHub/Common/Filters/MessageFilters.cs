using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class MessageFilters : ISortable<MessageSorting>
    {
        public MessageSorting SortingColumn { get; set; }
        public SortingOrder Order { get; set; }

        public DateTime? SendDate { get; set; }
        public string Title { get; set; }
        public string SenderName { get; set; }
    }
}
