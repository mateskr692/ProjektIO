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
        public ActionResult View(long? Id)
        {
            if (Id == null)
            {
                return this.RedirectToAction("Index");
            }

            var response = this.CommunityService.GetById(Id.Value);
            if (response.Status == ValidationStatus.Failed)
            {
                return this.Redirect(this.Url.Action());
            }

            return this.View(CommunitiesMapper.Default.Map<CommunityViewModel>(response.Data));
        }
  
    }
}