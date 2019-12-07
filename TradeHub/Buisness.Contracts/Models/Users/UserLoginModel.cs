using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    //pola potrzebne do zalogowania
    public class UserLoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
