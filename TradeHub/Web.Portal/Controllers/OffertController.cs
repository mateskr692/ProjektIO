using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buisness.Contracts.Models;
using Buisness.Core.Services;
using Common.Enums;
using Web.Portal.Code;
using Web.Portal.Models;

namespace Web.Portal.Controllers
{
    public class OffertController : BaseController
    {
        private UserService userService = new UserService();
        private OffertService offertService = new OffertService();
        private ToolService toolService = new ToolService();

        [HttpGet]
        [Route( template: "Offerts/Create/User={recievierUserId}/tool={toolId}", Name = "CreateOffert" )]
        public ActionResult Create(long? recievierUserId, long? toolId)
        {
            if(recievierUserId == null || toolId == null)
            {
               return this.RedirectToAction( "Error", "Home" );
            }

            var offerModel = new OffertViewModel
            {
                ReceiverId = recievierUserId,
                SenderId = this.CurrentUser.Id,
                ReceiverToolId = toolId
            };

            var userTools = this.toolService.GetUserToolsDictionary( this.CurrentUser.Id );
            if( userTools.Status == ValidationStatus.Failed)
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            var createModel = new OffertCreateViewModel()
            {
                OffertModel = offerModel,
                SenderToolsDictionary = userTools.Data
            };

            return this.View( createModel );
        }

        [HttpPost]
        [Route( template: "Offerts/Create", Name = "DoCreateOffert" )]
        public ActionResult Create( OffertCreateViewModel viewModel )
        {
            if( viewModel == null)
            {
                return this.RedirectToAction( "Error", "Home" );
            }
            if( viewModel.OFfertsSendersTool == false)
            {
                viewModel.OffertModel.SenderToolId = null;
            }

            var response = this.offertService.AddOffert( OffertMapper.Default.Map<OffertModel>( viewModel.OffertModel ) );
            return this.View( "OffertSuccess" );
        }

        [HttpGet]
        [Route( template: "Offerts/Recieved", Name = "RecievedOfferts" )]
        public ActionResult RecievedOfferts()
        {
            var response = this.offertService.GetUserRecievedOfferts( this.CurrentUser.Id );
            if(response.Status == ValidationStatus.Failed)
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            var offerts = OffertMapper.Default.Map<OffertIndexViewModel>( response.Data );
            return this.View( offerts );
        }

        [HttpGet]
        [Route( template: "Offerts/Sent", Name = "SentOfferts" )]
        public ActionResult SentOfferts()
        {
            var response = this.offertService.GetUserSubmittedOfferts( this.CurrentUser.Id );
            if ( response.Status == ValidationStatus.Failed )
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            var offerts = OffertMapper.Default.Map<OffertIndexViewModel>( response.Data );
            return this.View( offerts );
        }

        [HttpPost]
        [Route( template: "Offerts/{offertId}/Decline", Name = "DeclineOffert" )]
        public ActionResult Decline( long offertId )
        {
            var response = this.offertService.DeclineOffert( offertId, this.CurrentUser.Id );
            if ( response.Status == ValidationStatus.Failed )
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            return this.RedirectToAction( "RecievedOfferts" );
        }

        [HttpGet]
        [Route( template: "Offerts/{offertId}/Accept", Name = "AcceptOffert" )]
        public ActionResult Accept( long? offertId )
        {
            if( offertId == null)
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            var response = this.offertService.GetOffert( offertId.Value );
            if(response.Status == ValidationStatus.Failed)
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            var acceptModel = new OffertAcceptViewModel
            {
                Offert = OffertMapper.Default.Map<OffertViewModel>( response.Data ),
                Transaction = new TransactionViewModel()
            };

            acceptModel.Transaction.IsFinished = false;
            acceptModel.Transaction.BorowerId = acceptModel.Offert.SenderId;
            acceptModel.Transaction.LenderId = acceptModel.Offert.ReceiverId;
            acceptModel.Transaction.BorowerToolId = acceptModel.Offert.SenderToolId;
            acceptModel.Transaction.LenderToolId = acceptModel.Offert.ReceiverToolId;
            acceptModel.Transaction.StartDate = DateTime.Now;
            acceptModel.Transaction.BorrowerComment = acceptModel.Offert.Comment;
            acceptModel.Transaction.FinishDate = acceptModel.Offert.ProposedReturn;

            return this.View( acceptModel );
        }

        [HttpPost]
        [Route( template: "Offerts/Accept", Name = "DoAcceptOffert" )]
        public ActionResult Accept( OffertAcceptViewModel viewModel )
        {
            var response = this.offertService.AcceptOffert( viewModel.Offert.Id, this.CurrentUser.Id, TransactionMapper.Default.Map<TransactionModel>(viewModel.Transaction) );
            if ( response.Status == ValidationStatus.Failed )
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            return this.RedirectToAction( "RecievedOfferts" );
        }

    }
}