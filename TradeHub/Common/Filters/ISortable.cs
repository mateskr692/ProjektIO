using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public interface ISortable<TSorting>
        where TSorting : Enum
    {
        TSorting SortingColumn { get; set; }
        SortingOrder Order { get; set; }
    }
}
