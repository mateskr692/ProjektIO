using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Buisness.Contracts.Models
{
    public class UserModel
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
