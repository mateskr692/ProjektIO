using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Buisness.Contracts;
using Buisness.Contracts.Models;
using Buisness.Core.Mappers;
using Common.Enums;
using Common.Filters;
using Data.DAL;

namespace Buisness.Core.Services
{
    public class TransactionService
    {
        public WResult<TransactionModel> GetTransaction(long transactionId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var transaction = uow.Transactions.GetById( transactionId );
                if( transaction == null)
                {
                    return new WResult<TransactionModel>( ValidationStatus.Failed, "Transaction does not exist" );
                }

                var transactionModel = TransactionMapper.Default.Map<TransactionModel>( transaction );
                uow.Complete();

                return new WResult<TransactionModel>( ValidationStatus.Succeded, errors: null, data: transactionModel );
            }
        }

        public WResult<TransactionIndexModel> GetUserLendingTransactions(long userId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var transactions = uow.Transactions.GetUserLendingTransactions( userId );
                var transactionModel = new TransactionIndexModel
                {
                    Filters = new TransactionFilters(),
                    Transactions = TransactionMapper.Default.Map<List<TransactionInfoModel>>( transactions )
                };

                uow.Complete();
                return new WResult<TransactionIndexModel>( ValidationStatus.Succeded, errors: null, data: transactionModel );
            }
        }

        public WResult<TransactionIndexModel> GetUserBorrowingTransactions( long userId )
        {
            using ( var uow = new UnitOfWork() )
            {
                var transactions = uow.Transactions.GetUserBorrowingTransactions( userId );
                var transactionModel = new TransactionIndexModel
                {
                    Filters = new TransactionFilters(),
                    Transactions = TransactionMapper.Default.Map<List<TransactionInfoModel>>( transactions )
                };

                uow.Complete();
                return new WResult<TransactionIndexModel>( ValidationStatus.Succeded, errors: null, data: transactionModel );
            }
        }

        public WResult FinishTransaction(long transactionId, int score)
        {
            using ( var uow = new UnitOfWork() )
            {
                var transaction = uow.Transactions.GetById( transactionId );
                if(transaction == null)
                {
                    return new WResult( ValidationStatus.Failed, "Trnasaction does not exist and cant be finished" );
                }

                transaction.IsFinished = true;
                transaction.FinishDate = DateTime.Now;
                transaction.LenderOpinion = score;

                var lenderTool = uow.Tools.GetById( transaction.LenderToolId.Value );
                lenderTool.Availability = true;

                if ( transaction.BorowerToolId != null )
                {
                    var borrowerTool = uow.Tools.GetById( transaction.BorowerToolId.Value );
                    borrowerTool.Availability = true;
                }

                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }



        public int GetUserTotalOpinion( long userId )
        {
            using ( var uow = new UnitOfWork() )
            {
                var score = uow.Transactions.GetUserTotalOpinion( userId );
                uow.Complete();

                return score;
            }
        }

        public double GetUserAverageOpinion( long userId )
        {
            using ( var uow = new UnitOfWork() )
            {
                var score = uow.Transactions.GetUserAverageOpinion( userId );
                uow.Complete();

                return score;
            }
        }


        public WResult RateLender(long transactionId, int score )
        {
            using ( var uow = new UnitOfWork() )
            {
                var transaction = uow.Transactions.GetById( transactionId );
                if ( transaction == null )
                {
                    return new WResult( ValidationStatus.Failed, "Trnasaction does not exist" );
                }

                transaction.BorrowerOpinion = score;
                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }
    }
}
