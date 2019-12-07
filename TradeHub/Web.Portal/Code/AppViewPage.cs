using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Web.Portal.Code
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUser CurrentUser => new AppUser( this.User as ClaimsPrincipal );
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}