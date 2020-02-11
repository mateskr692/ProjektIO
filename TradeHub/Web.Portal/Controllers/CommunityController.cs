using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Portal.Code;
using Buisness.Core.Services;
using Buisness.Contracts.Models;
using Common.Enums;
using Common.Filters;
using Web.Portal.Models;

namespace Web.Portal.Controllers
{
    public class CommunityController : BaseController
    {
        private CommunityService CommunityService = new CommunityService();
        private ToolService ToolService = new ToolService();
        private UserService UserService = new UserService();

        // GET: Communities
        [Route( template: "Community" )]
        public ActionResult Index(CommunityFilters filters)
        {
            var response = this.CommunityService.GetPaged(filters);
            return this.View(CommunitiesMapper.Default.Map<CommunityIndexViewModel>(response.Data));
        }


        [HttpGet]
        [Route( template: "Community/Create" )]
        public ActionResult Create()
        {
            return this.View("Create");
        }


        [HttpPost]
        [Route( template: "Community/Create" )]
        public ActionResult Create(CommunityViewModel communityModel, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(communityModel);
            }

            //TODO: automatically add user to the community he creates
            var response = this.CommunityService.
                AddCommunity(CommunitiesMapper.Default.Map<CommunityModel>(communityModel), this.CurrentUser.Id);

            if (response.Status == ValidationStatus.Failed)
            {
                foreach (var err in response.Errors)
                    this.ModelState.AddModelError("", err);

                return this.View(communityModel);
            }
            return this.RedirectToAction("Index");
        }


        [HttpGet]
        [Route(template: "Community/{communityId}", Name = "Community")]
        public ActionResult View(long? communityId)
        {
            if ( communityId == null)
            {
                return this.RedirectToAction("Index");
            }

            var response = this.CommunityService.GetById( communityId.Value);
            if (response.Status == ValidationStatus.Failed)
            {
                return this.Redirect(this.Url.Action());
            }

            this.ViewData[ "IsMember" ] = this.CommunityService.IsUserInCommunity( this.CurrentUser.Id, communityId.Value );

            return this.View(CommunitiesMapper.Default.Map<CommunityViewModel>(response.Data));
        }

        [HttpGet]
        [Route( template: "Community/{communityId}/Tool", Name = "CommunityTools" )]
        public ActionResult Tools( long? communityId, ToolFilters filters )
        {
            //TODO: Check if user is in community, if not do not allow him to view the community tools
            if ( communityId == null )
            {
                //todo: add some error message
            }

            var communityResponse = this.CommunityService.GetById( communityId.Value );
            if ( communityResponse.Status == Common.Enums.ValidationStatus.Failed )
            {
                //todo: community doesnt exist
            }
            //set name of community to display on the page
            this.ViewData[ "CommunityName" ] = communityResponse.Data.Name;
            this.ViewData[ "Id" ] = communityId;

            //get all non-hidden tools of every user in the community
            var response = this.ToolService.GetCommunityTools( filters, communityId.Value );
            if( response.Status == ValidationStatus.Failed )
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            return this.View( ToolsMapper.Default.Map<ToolIndexViewModel>( response.Data ) );
        }

        [HttpGet]
        [Route( template: "Community/{communityId}/User", Name = "CommunityUsers" )]
        public ActionResult Users( long? communityId, UserFilters filters )
        {
            //TODO: Check if user is in community, if not do not allow him to view the community tools
            if ( communityId == null )
            {
                //todo: add some error message
            }

            var communityResponse = this.CommunityService.GetById( communityId.Value );
            if ( communityResponse.Status == Common.Enums.ValidationStatus.Failed )
            {
                //todo: community doesnt exist
            }
            //set name of community to display on the page
            this.ViewData[ "CommunityName" ] = communityResponse.Data.Name;
            this.ViewData[ "Id" ] = communityId;

            //get all non-hidden tools of every user in the community
            var response = this.UserService.GetCommunityUsers( filters, communityId.Value );
            if ( response.Status == ValidationStatus.Failed )
            {
                return this.RedirectToAction( "Error", "Home" );
            }
            return this.View( UsersMapper.Default.Map<UserIndexViewModel>( response.Data ) );
        }

        [HttpPost]
        [Route( template: "Community/{communityId}/Join", Name = "JoinCommunity" )]
        public ActionResult Join( long communityId )
        {
            var response = this.CommunityService.RequestToJoin( communityId, this.CurrentUser.Id );

            if ( response.Status == ValidationStatus.Failed )
            {
                /* TODO: this scenario can be done better
                 foreach (var err in response.Errors)
                    this.ModelState.AddModelError("", err);
                 */
                return this.View( "Error" );
            }

            return this.View();
        }

        [HttpPost]
        [Route( template: "Community/{communityId}/Leave", Name = "LeaveCommunity" )]
        public ActionResult Leave( long communityId )
        {
            var response = this.CommunityService.RemoveUser( communityId, this.CurrentUser.Id );

            if ( response.Status == ValidationStatus.Failed )
            {
                /* TODO: this scenario can be done better
                 foreach (var err in response.Errors)
                    this.ModelState.AddModelError("", err);
                 */
                return this.View( "Error" );
            }

            return this.View();
        }

    }
}