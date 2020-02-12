using System;
using System.Collections.Generic;
using System.IO;
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
    public class TransactionController : BaseController
    {
        private TransactionService TransactionService = new TransactionService();

        [HttpGet]
        [Route( template: "Transactions/{transactionId}", Name = "Transaction" )]
        public ActionResult View(long? transactionId)
        {
            if(transactionId == null)
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            var response = this.TransactionService.GetTransaction( transactionId.Value );
            if( response.Status == Common.Enums.ValidationStatus.Failed)
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            return this.View( TransactionMapper.Default.Map<TransactionViewModel>( response.Data ) );
        }

        [HttpGet]
        [Route( template: "Transactions/Lending", Name = "LendingTransactions" )]
        public ActionResult Lending()
        {
            var response = this.TransactionService.GetUserLendingTransactions( this.CurrentUser.Id );
            if(response.Status == ValidationStatus.Failed)
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            return this.View( TransactionMapper.Default.Map<TransactionIndexViewModel>( response.Data ) );

        }

        [HttpGet]
        [Route( template: "Transactions/Borrowing", Name = "BorrowingTransactions" )]
        public ActionResult Borrowing()
        {
            var response = this.TransactionService.GetUserBorrowingTransactions( this.CurrentUser.Id );
            if ( response.Status == ValidationStatus.Failed )
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            return this.View( TransactionMapper.Default.Map<TransactionIndexViewModel>( response.Data ) );
        }

        [HttpGet]
        [Route( template: "Transactions/{transactionId}/Finish", Name = "FinishTransaction" )]
        public ActionResult Finish( long? transactionId )
        {
            if ( transactionId == null )
            {
                return this.RedirectToAction( "Error", "Home" );
            }

            return null;
        }

        [HttpPost]
        [Route( template: "Transactions/{transactionId}/Finish", Name = "DoFinishTransaction" )]
        public ActionResult Finish( TransactionViewModel transactionModel )
        {
            return null;
        }

        [HttpGet]
        public ActionResult Rate( long? transactionId)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Rate( TransactionViewModel viewModel )
        {
            return null;
        }
    }
}