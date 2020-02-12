using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Portal.Models
{
    public class TransactionInfoViewModel
    {
        public long Id { get; set; }
        public bool IsFinished { get; set; }

        public string LenderName { get; set; }
        public string BorowerName { get; set; }
        public string LenderToolName { get; set; }
        public string BorowerToolName { get; set; }
    }
}