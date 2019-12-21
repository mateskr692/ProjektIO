using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buisness.Core.Mappers;
using Buisness.Core.Services;
using Common.Enums;
using Web.Portal.Models;

namespace Web.Portal.Controllers
{
    public class CommunitiesController : Controller
    {
        private CommunityService CommunityService = new CommunityService();

        // GET: Communities
        public ActionResult Index()
        {
            return this.View();
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

    }
}