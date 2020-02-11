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
        private CommunityService CommunityService = new CommunityService();
        private ToolService ToolService = new ToolService();




        //both Get when going first time and POST when submitting filters
        public ActionResult Index(UserFilters filters)
        {
            var response = this.UserService.GetPaged( filters );
            return this.View( UsersMapper.Default.Map<UserIndexViewModel>( response.Data ) );
        }

        [HttpGet]
        [Route( template: "User/{userId}", Name = "User" )]
        public ActionResult View( long? userId )
        {
            if(userId  == null)
            {
                return this.RedirectToAction( "Index" );
            }

            var response = this.UserService.GetById( userId .Value );
            if (response.Status == ValidationStatus.Failed)
            {
                //narazie tylko powrot do przegladania, trzeba by dodac jakiegos modala z info ze cos poszlo nie tak
                return this.Redirect( this.Url.Action() );
            }
            
            return this.View( UsersMapper.Default.Map<UserViewModel>( response.Data ) );
        }

        [HttpGet]
        [Route( template: "User/Edit", Name = "EditUser" )]
        public ActionResult Edit()
        {
            var response = this.UserService.GetById( this.CurrentUser.Id );
            if( response.Status == ValidationStatus.Failed)
            {
                //todo
                return this.RedirectToAction( "Home", "Error" );
            }

            return this.View( UsersMapper.Default.Map<UserViewModel>( response.Data ) );
        }

        [HttpPost]
        [Route( template: "User/Edit", Name = "DoEditUser" )]
        public ActionResult Edit( UserViewModel userModel )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.View( userModel );
            }

            userModel.Id = this.CurrentUser.Id;
            var response = this.UserService.UpdateUserInfo( UsersMapper.Default.Map<UserModel>( userModel ) );

            if ( response.Status == ValidationStatus.Failed )
            {
                foreach ( var err in response.Errors )
                    this.ModelState.AddModelError( "", err );

                return this.View( userModel );
            }
            return this.RedirectToAction( "View", new { userId = this.CurrentUser.Id } );
        }


        [HttpGet]
        [Route( template: "User/Communities", Name = "UserCommunities" )]
        public ActionResult Cummunities( UserFilters filters )
        {
            var response = this.CommunityService.GetUserCommunities( filters, this.CurrentUser.Id );

            if ( response.Status == ValidationStatus.Failed )
            {
                return this.Redirect( this.Url.Action() );
            }

            return this.View( CommunitiesMapper.Default.Map<CommunityIndexViewModel>( response.Data ) );
            //return this.View();
        }



        [Route( template: "User/Tool", Name = "UserTools" )]
        [HttpGet]
        public ActionResult Tool( ToolFilters filters )
        {
            var response = this.ToolService.GetUserTools( filters, this.CurrentUser.Id );
            return this.View( ToolsMapper.Default.Map<ToolIndexViewModel>( response.Data ) );
        }

        [HttpGet]
        [Route( template: "User/Tool/{toolId}", Name = "UserTool" )]
        //wszystkie parametry w Url powinny byc nullowalne bo zawsze mozna wpisac urla bez nich
        public ActionResult ViewTool( long? toolId )
        {
            if ( toolId == null )
            {
                this.RedirectToAction( "Index" );
            }

            var response = this.ToolService.GetById( toolId.Value );
            if ( response.Status == ValidationStatus.Failed )
            {
                //narazie tylko powrot do przegladania, trzeba by dodac jakiegos modala z info ze cos poszlo nie tak
                return this.Redirect( this.Url.Action() );
            }

            return this.View( ToolsMapper.Default.Map<ToolViewModel>( response.Data ) );
        }

        [HttpGet]
        [Route( template: "User/Tool/Add", Name = "AddUserTool" )]
        public ActionResult CreateTool()
        {
            return this.View();
        }


        [HttpPost]
        [Route( template: "User/Tool/Add", Name = "DoAddUserTool" )]
        public ActionResult CreateTool( ToolViewModel toolModel, string returnUrl )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.View( toolModel );
            }

            toolModel.UserId = this.CurrentUser.Id;

            var response = this.ToolService.
                AddUserTool( ToolsMapper.Default.Map<ToolModel>( toolModel ), this.CurrentUser.Id );

            if ( response.Status == ValidationStatus.Failed )
            {
                foreach ( var err in response.Errors )
                    this.ModelState.AddModelError( "", err );

                return this.View( toolModel );
            }
            return this.RedirectToAction( "Tool" );
        }

        [HttpPost]
        [Route( template: "User/Tool/{toolId}/Delete", Name = "DeleteUserTool" )]
        public ActionResult DeleteTool( long toolId )
        {
            var response = this.ToolService.Delete( toolId );
            return this.RedirectToAction( "Tool" );
        }

        [HttpGet]
        [Route( template: "User/Tool/{toolId}/Edit", Name = "EditUserTool" )]
        public ActionResult EditTool( long? toolId )
        {
            if ( toolId == null )
            {
                this.RedirectToAction( "Index" );
            }

            var response = this.ToolService.GetById( toolId.Value );
            if ( response.Status == ValidationStatus.Failed )
            {
                //narazie tylko powrot do przegladania, trzeba by dodac jakiegos modala z info ze cos poszlo nie tak
                return this.Redirect( this.Url.Action() );
            }

            return this.View( ToolsMapper.Default.Map<ToolViewModel>( response.Data ) );
        }

        [HttpPost]
        [Route( template: "User/Tool/{toolId}/Edit", Name = "DoEditUserTool" )]
        public ActionResult EditTool( ToolViewModel toolModel, string returnUrl )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.View( toolModel );
            }

            toolModel.UserId = this.CurrentUser.Id;
            var response = this.ToolService.Update( ToolsMapper.Default.Map<ToolModel>( toolModel ) );

            if ( response.Status == ValidationStatus.Failed )
            {
                foreach ( var err in response.Errors )
                    this.ModelState.AddModelError( "", err );

                return this.View( toolModel );
            }
            return this.RedirectToAction( "ViewTool", new { toolId = toolModel.Id } );
        }

    }
}