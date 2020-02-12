using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Portal.Models
{
    public class TransactionRateViewModel
    {
        public long TransactionId { get; set; }

        [Range( -5, 5 )]
        public int Score { get; set; }
    }
}