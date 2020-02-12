using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Filters;

namespace Buisness.Contracts.Models
{
    public class TransactionIndexModel
    {
        public TransactionFilters Filters { get; set; }
        public List<TransactionInfoModel> Transactions { get; set; }
    }
}
