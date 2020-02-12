using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    public class OffertModel
    {
        public long Id { get; set; }

        public DateTime ProposedReturn { get; set; } = DateTime.Now;
        public string Comment { get; set; }
        //public int State { get; set; }
        public long? SenderId { get; set; }
        public long? ReceiverId { get; set; }
        public long? SenderToolId { get; set; }
        public long? ReceiverToolId { get; set; }
    }
}
