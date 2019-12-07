using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Web.Portal.Code;
using Web.Portal.Models;

namespace Web.Portal.Controllers
{
    //bazowy kontroler dodajacy dodatkowe elementy do authoryzacji i sesji
    public class BaseController : Controller
    {
        private static readonly string AuthType = "ApplicationCookie";
        public AppUser CurrentUser => new AppUser( this.User as ClaimsPrincipal );

        public void Authorize( UserViewModel userViewModel )
        {
            var identity = new ClaimsIdentity( new[] {
                new Claim(ClaimTypes.Name, userViewModel.Login),
                new Claim(ClaimTypes.Email, userViewModel.Email),
                new Claim(ClaimTypes.Sid, userViewModel.Id.ToString() )
            },
            AuthType );

            this.Request.GetOwinContext().Authentication.SignIn( identity );
        }

        public void DeAuthorize()
        {
            this.Request.GetOwinContext().Authentication.SignOut( AuthType );
        }
    }
}