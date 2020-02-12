using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Portal.Models
{
    public class TransactionViewModel
    {
        public long Id { get; set; }
        public bool IsFinished { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public string StartLocation { get; set; }
        public string FinishLocation { get; set; }

        public int ToolState { get; set; }
        public string LenderComment { get; set; }
        public int LenderOpinion { get; set; }
        public string BorrowerComment { get; set; }
        public int BorrowerOpinion { get; set; }

        public long? LenderId { get; set; }
        public long? BorowerId { get; set; }
        public long? LenderToolId { get; set; }
        public long? BorowerToolId { get; set; }
    }
}