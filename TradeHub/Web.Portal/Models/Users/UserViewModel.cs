using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Enums;

namespace Web.Portal.Models
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public VisibilityType NameVisibility { get; set; }

        public string Contact { get; set; }
        public VisibilityType ContactVisibility { get; set; }

        public string Address { get; set; }
        public VisibilityType AdressVisibility { get; set; }
    }
}