using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Buisness.Contracts.Models
{
    public class UserRegisterModel
    {
        //obowiazkowe pola do rejestracji
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        //opcjonalne pola do rejestracji
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public VisibilityType NameVisibility { get; set; } = VisibilityType.Private;

        public string Contact { get; set; }
        public VisibilityType ContactVisibility { get; set; } = VisibilityType.Private;

        public string Adress { get; set; }
        public VisibilityType AdressVisibility { get; set; } = VisibilityType.Private;
    }
}
