using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Buisness.Contracts.Models;
using Buisness.Core.Services;
using Common.Enums;
using Common.Filters;
using Web.Portal.Code;
using Web.Portal.Models;

namespace Web.Portal.Controllers
{
    //kontroler do przegladania uzytkownikow w systemie i wyswietlania ich profili
    public class UserController : BaseController
    {
        private UserService UserService = new UserService();

        //both Get when going first time and POST when submitting filters
        public ActionResult Index(UserFilters filters)
        {
            var response = this.UserService.GetPaged( filters );
            return this.View( UsersMapper.Default.Map<UserIndexViewModel>( response.Data ) );
        }

        [HttpGet]
        //wszystkie parametry w Url powinny byc nullowalne bo zawsze mozna wpisac urla bez nich
        public ActionResult View(long? Id)
        {
            if(Id == null)
            {
                this.RedirectToAction( "Index" );
            }

            var response = this.UserService.GetById( Id.Value );
            if (response.Status == ValidationStatus.Failed)
            {
                //narazie tylko powrot do przegladania, trzeba by dodac jakiegos modala z info ze cos poszlo nie tak
                return this.Redirect( this.Url.Action() );
            }

            return this.View( UsersMapper.Default.Map<UserViewModel>( response.Data ) );
        }


    }
}