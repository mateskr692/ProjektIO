using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Filters;

namespace Web.Portal.Models
{
    public class CommunityIndexViewModel
    {
        public CommunityFilters Filters { get; set; }
        public List<CommunityInfoViewModel> Communities { get; set; }
    }
}