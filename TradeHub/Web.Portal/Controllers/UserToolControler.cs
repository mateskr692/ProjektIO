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
    public class UserToolController : BaseController
    {
        private ToolService ToolService = new ToolService();

        //both Get when going first time and POST when submitting filters
        public ActionResult Index(ToolFilters filters)
        {
            var response = this.ToolService.GetUserTools( filters, this.CurrentUser.Id);
            return this.View( ToolsMapper.Default.Map<ToolIndexViewModel>( response.Data ) );
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View("Create");
        }


        [HttpPost]
        public ActionResult Create(ToolViewModel toolModel, long userId, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(toolModel);
            }

            toolModel.UserId = this.CurrentUser.Id;

            var response = this.ToolService.
                AddUserTool(ToolsMapper.Default.Map<ToolModel>(toolModel), userId);

            if (response.Status == ValidationStatus.Failed)
            {
                foreach (var err in response.Errors)
                    this.ModelState.AddModelError("", err);

                return this.View(toolModel);
            }
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        //wszystkie parametry w Url powinny byc nullowalne bo zawsze mozna wpisac urla bez nich
        public ActionResult View(long? Id)
        {
            if(Id == null)
            {
                this.RedirectToAction( "Index" );
            }

            var response = this.ToolService.GetById( Id.Value );
            if (response.Status == ValidationStatus.Failed)
            {
                //narazie tylko powrot do przegladania, trzeba by dodac jakiegos modala z info ze cos poszlo nie tak
                return this.Redirect( this.Url.Action() );
            }

            return this.View( ToolsMapper.Default.Map<ToolViewModel>( response.Data ) );
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var response = this.ToolService.Delete( id );
            return this.RedirectToAction( "Index" );
        }

        [HttpPost]
        public ActionResult Edit(ToolViewModel toolModel)
        {
            toolModel.UserId = this.CurrentUser.Id;
            var response = this.ToolService.Update(ToolsMapper.Default.Map<ToolModel>(toolModel));
            return this.RedirectToAction("Index");
        }

    }
}