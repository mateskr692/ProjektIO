using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buisness.Core.Services;
using Common.Filters;
using Web.Portal.Code;
using Web.Portal.Models;

namespace Web.Portal.Controllers
{
    public class CommunityToolController : BaseController
    {
        private ToolService ToolService = new ToolService();
        private CommunityService CommunityService = new CommunityService();

        [HttpGet]
        public ActionResult Index( ToolFilters filters, long? communityId)
        {
            if ( communityId == null )
            {
                //todo: add some error message
            }

            var communityResponse = this.CommunityService.GetById( communityId.Value );
            if( communityResponse.Status == Common.Enums.ValidationStatus.Failed )
            {
                //todo: community doesnt exist
            }
            //set name of community to display on the page
            this.ViewData[ "CommunityName" ] = communityResponse.Data.Name;

            //get all non-hidden tools of every user in the community
            var response = this.ToolService.GetCommunityTools( filters, communityId.Value );
            return this.View( ToolsMapper.Default.Map<ToolIndexViewModel>( response.Data ) );
        }
    }
}