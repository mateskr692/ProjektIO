using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Buisness.Contracts.Models;
using Buisness.Core.Services;
using Common.Enums;
using Web.Portal.Code;
using Web.Portal.Models;

namespace Web.Portal.Controllers
{
    //kontroler do tworzenia i zarzadzania kontem uzytkownika
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private AccountService UserService = new AccountService();

        #region Rejestracja
        [HttpGet]
        public ActionResult Register()
        {
            if ( this.User.Identity.IsAuthenticated )
            {
                //TODO: (MS) powrot na wczesniejsza strone / pokazanie modala
                return this.Redirect( "/" );
            }

            //Strona do rejestracji
            return this.View();
        }

        [HttpPost]
        public ActionResult Register( UserRegisterViewModel registerModel, string returnUrl )
        {
            if ( !this.ModelState.IsValid )
                return this.View( registerModel );

            var response = this.UserService.Register( UsersMapper.Default.Map<UserRegisterModel>( registerModel ) );
            if ( response.Status == ValidationStatus.Failed )
            {
                foreach ( var err in response.Errors )
                    this.ModelState.AddModelError( "", err );

                return this.View( registerModel );
            }

            //TODO: (MS) dodac wysylanie maila i pole Verified do uzytkownika w bd
            return this.RedirectToAction( "Login" );
        }
        #endregion


        #region Logowanie
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if ( this.User.Identity.IsAuthenticated )
            {
                //TODO: (MS) powrot na wczesniejsza strone / pokazanie modala
                return this.Redirect( returnUrl ?? "/" );
            }

            return this.View();

        }

        [HttpPost]
        public ActionResult Login( UserLoginViewModel loginModel, string returnUrl )
        {
            if ( !this.ModelState.IsValid )
                return this.View( loginModel );

            var response = this.UserService.Login( UsersMapper.Default.Map<UserLoginModel>( loginModel ) );
            if ( response.Status == ValidationStatus.Failed )
            {
                foreach ( var err in response.Errors )
                    this.ModelState.AddModelError( "", err );

                return this.View( loginModel );
            }

            this.Authorize( UsersMapper.Default.Map<UserViewModel>( response.Data ) );
            return this.Redirect( returnUrl ?? "/" );
        }

        public ActionResult Logout( string returnUrl )
        {
            if( this.CurrentUser.Identity.IsAuthenticated )
                this.DeAuthorize();

            return this.Redirect( returnUrl ?? "/" );
        }
        #endregion


        #region Resetowanie
        [HttpGet]
        public ActionResult Reset()
        {
            //TODO: (MS) wysylanie na podany mail linku do zmiany hasla
            return this.View();
        }

        //zmiana hasla wymaga bycia zalogowanym
        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            //TODO: (MS) zmiana hasla
            return this.View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword( string returnUrl )
        {
            //TODO: (MS) zmiana hasla
            return this.View();
        }
        #endregion
    }
}