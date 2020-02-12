using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    public class TransactionInfoModel
    {
        public long Id { get; set; }
        public bool IsFinished { get; set; }

        public string LenderName { get; set; }
        public string BorowerName { get; set; }
        public string LenderToolName { get; set; }
        public string BorowerToolName { get; set; }
    }
}
