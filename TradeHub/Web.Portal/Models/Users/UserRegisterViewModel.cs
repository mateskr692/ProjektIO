using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Common.Enums;

namespace Web.Portal.Models
{
    public class UserRegisterViewModel
    {
        //obowiazkowe pola do rejestracji
        [Required]
        [StringLength(5)]
        public string Login { get; set; }

        [Required]
        [StringLength(8)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //opcjonalne pola do rejestracji
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public VisibilityType NameVisibility { get; set; } = VisibilityType.Private;

        public string Contact { get; set; }
        public VisibilityType ContactVisibility { get; set; } = VisibilityType.Private;

        public string Adress { get; set; }
        public VisibilityType AdressVisibility { get; set; } = VisibilityType.Private;

        public string ReturnUrl { get; set; }
    }
}