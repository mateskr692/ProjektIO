using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Filters;

namespace Web.Portal.Models
{
    public class RequestIndexViewModel
    {
        public RequestFilters Filters { get; set; }
        public List<RequestInfoViewModel> Requests { get; set; }
    }
}