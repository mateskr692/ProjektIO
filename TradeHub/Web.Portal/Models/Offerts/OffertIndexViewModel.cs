using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Filters;

namespace Web.Portal.Models
{
    public class OffertIndexViewModel
    {
        public OffertFilters Filters { get; set; }
        public List<OffertInfoViewModel> Offerts { get; set; }
    }
}