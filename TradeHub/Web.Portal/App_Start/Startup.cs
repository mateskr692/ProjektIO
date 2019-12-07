using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Web.Portal
{
    public class Startup
    {
        public void Configuration( IAppBuilder app )
        {
            app.UseCookieAuthentication( new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString( "/account/login" )
            } );
        }
    }
}