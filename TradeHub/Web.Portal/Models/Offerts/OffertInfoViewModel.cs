using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Portal.Models
{
    public class OffertInfoViewModel
    {
        public long Id { get; set; }

        public string SenderName { get; set; }
        public string RecieverName { get; set; }

        public string SenderToolName { get; set; }
        public string ReceiverToolName { get; set; }
    }
}