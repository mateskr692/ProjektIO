//using Buisness.Core.Services;
//using Web.Portal.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Common.Enums;
//using Web.Portal.Code;
//using Common.Filters;

//namespace Web.Portal.Controllers
//{
//    public class UserCommunitiesController : BaseController
//    {
//        private CommunityService CommunityService = new CommunityService();

//        //TODO: move the Index Action into the UserController using RESTfull API ( User/1/Communities )
//        //      move the Join and Leave Actions into the CommunityControler using RESTfull API ( Community/4/Join )
//        //      ask user for confirmation before leaving the community (Are you sure you want to leave the "xxx": yes, no )
//        //      eventually replace Join action with RequestToJoin, which one of the users in community will have to accept
            
//        //TODO: Delete this controller after removing all actions
    

//        [HttpGet]
//        public ActionResult Index()
//        {
//            var response = this.CommunityService.GetUserCommunities(this.CurrentUser.Id);

//            if (response.Status == ValidationStatus.Failed)
//            {
//                return this.Redirect(this.Url.Action());
//            }

//            return this.View(CommunitiesMapper.Default.Map<CommunityIndexViewModel>(response.Data));
//            //return this.View();
//        }

//        [HttpPost]
//        public ActionResult Join(long CommunityId)
//        {
//            var response = this.CommunityService.AddUserToCommunity(CommunityId, this.CurrentUser.Id);

//            if (response.Status == ValidationStatus.Failed)
//            {
//                /* TODO: this scenario can be done better
//                 foreach (var err in response.Errors)
//                    this.ModelState.AddModelError("", err);
//                 */
//                return this.View("Error");
//            }

//            return this.View();
//        }

//        [HttpPost]
//        public ActionResult Leave(long CommunityId)
//        {
//            var response = this.CommunityService.RemoveUserFromCommunity(CommunityId, this.CurrentUser.Id);

//            if (response.Status == ValidationStatus.Failed)
//            {
//                /* TODO: this scenario can be done better
//                 foreach (var err in response.Errors)
//                    this.ModelState.AddModelError("", err);
//                 */
//                return this.View("Error");
//            }

//            return this.View();
//        }

//    }
//}