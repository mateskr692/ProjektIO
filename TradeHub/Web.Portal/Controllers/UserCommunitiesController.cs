using Buisness.Core.Services;
using Web.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Enums;
using Buisness.Core.Mappers;

namespace Web.Portal.Controllers
{
    public class UserCommunitiesController : BaseController
    {
        private CommunityService CommunityService = new CommunityService();

        // GET: UserCommunities
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult ViewMyCommunities()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Join(long CommunityId)
        {
            var response = this.CommunityService.AddUserToCommunity(CommunityId, this.CurrentUser.Id);

            if (response.Status == ValidationStatus.Failed)
            {
                /* TODO: this scenario can be done better
                 foreach (var err in response.Errors)
                    this.ModelState.AddModelError("", err);
                 */
                return this.View("Error");
            }

            return this.View();
        }

        [HttpPost]
        public ActionResult Leave(long CommunityId)
        {
            var response = this.CommunityService.RemoveUserFromCommunity(CommunityId, this.CurrentUser.Id);

            if (response.Status == ValidationStatus.Failed)
            {
                /* TODO: this scenario can be done better
                 foreach (var err in response.Errors)
                    this.ModelState.AddModelError("", err);
                 */
                return this.View("Error");
            }

            return this.View();
        }

    }
}