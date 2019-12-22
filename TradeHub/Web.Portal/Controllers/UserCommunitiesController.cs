using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Portal.Controllers
{
    public class UserCommunitiesController : Controller
    {

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

        public ActionResult Join(long? CommunityId)
        {
            if (CommunityId == null)
            {
                this.RedirectToAction("Index");
            }

            // CommunityRepository.AddUserToCommunity(CommunityId, UserId)

            return this.View();
        }

        public ActionResult Leave(long? CommunityId)
        {
            if (CommunityId == null)
            {
                this.RedirectToAction("Index");
            }

            // CommunityRepository.RemoveUserFromCommunity(CommunityId, UserId)

            return this.View();
        }
    }
}