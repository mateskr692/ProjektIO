using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Filters;

namespace Web.Portal.Models
{
    public class UserIndexViewModel
    {
        public UserFilters Filters { get; set; }
        public List<UserInfoViewModel> Users { get; set; }
    }
}