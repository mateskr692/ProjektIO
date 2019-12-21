using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Portal.Code;
using Buisness.Core.Services;
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
        public ActionResult ViewById(long? Id)
        {
            if (Id == null)
            {
                this.RedirectToAction("Index");
            }

            var response = this.CommunityService.GetById(Id.Value);
            if (response.Status == ValidationStatus.Failed)
            {
                return this.Redirect(this.Url.Action());
            }

            return this.View(CommunitiesMapper.Default.Map<CommunityViewModel>(response.Data));
        }

        [HttpGet]
        public ActionResult View(CommunityFilters filters)
        {
            var response = this.CommunityService.GetPaged(filters);

            if (response.Status == ValidationStatus.Failed)
            {
                return this.Redirect(this.Url.Action());
            }

            return this.View(CommunitiesMapper.Default.Map<CommunityViewModel>(response.Data));
        }
    }
}