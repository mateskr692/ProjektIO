﻿using System;
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

        // GET: Communities
        public ActionResult Index(CommunityFilters filters)
        {
            var response = this.CommunityService.GetPaged(filters);
            return this.View(CommunitiesMapper.Default.Map<CommunityIndexViewModel>(response.Data));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return this.View("Create");
        }


        [HttpPost]
        public ActionResult Create(CommunityViewModel communityModel, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(communityModel);
            }

            //TODO: automatically add user to the community he creates
            var response = this.CommunityService.
                AddCommunity(CommunitiesMapper.Default.Map<CommunityModel>(communityModel));

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
            return this.View( ToolsMapper.Default.Map<ToolIndexViewModel>( response.Data ) );
        }

    }
}