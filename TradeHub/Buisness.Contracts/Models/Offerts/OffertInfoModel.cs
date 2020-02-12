using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    public class OffertInfoModel
    {
        public long Id { get; set; }

        public string SenderName { get; set; }
        public string RecieverName { get; set; }

        public string SenderToolName { get; set; }
        public string ReceiverToolName { get; set; }
    }
}
