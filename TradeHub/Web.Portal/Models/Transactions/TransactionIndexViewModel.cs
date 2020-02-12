using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Filters;

namespace Web.Portal.Models
{
    public class TransactionIndexViewModel
    {
        public TransactionFilters Filters { get; set; }
        public List<TransactionInfoViewModel> Transactions { get; set; }
    }
}