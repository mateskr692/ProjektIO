using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Web.Portal.Code
{
    //cachowane dane do cisateczka podczas authoryzacji
    public class AppUser : ClaimsPrincipal
    {
        public AppUser( ClaimsPrincipal principal ) : base( principal )
        {
        }

        public string Name => this.FindFirst( ClaimTypes.Name )?.Value ?? "";
        public string Email => this.FindFirst( ClaimTypes.Email )?.Value ?? "";
        public long Id => long.Parse( this.FindFirst( ClaimTypes.Sid )?.Value );
    }
}