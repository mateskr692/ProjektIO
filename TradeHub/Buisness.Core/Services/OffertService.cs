using Buisness.Contracts;
using Common.Enums;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Contracts.Models;
using Common.Filters;
using Buisness.Core.Mappers;

namespace Buisness.Core.Services
{
    public class OffertService
    {
        public WResult AddOffert(OffertModel offertModel)
        {
            using ( var uow = new UnitOfWork() )
            {
                var offert = OffertMapper.Default.Map<Offert>( offertModel );
                uow.Offerts.Add( offert );
                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }

        public WResult AcceptOffert(long offertId, long userId, TransactionModel transaction)
        {
            using ( var uow = new UnitOfWork() )
            {
                var offert = uow.Offerts.GetById( offertId );
                if(offert == null)
                {
                    return new WResult( ValidationStatus.Failed, "Offert does not exist" );
                }

                //Create Transaction Entry
                var newTransaction = TransactionMapper.Default.Map<Transaction>( transaction );
                uow.Transactions.Add( newTransaction );
                uow.Offerts.Remove( offert );

                var lenderTool = uow.Tools.GetById( transaction.LenderToolId.Value );
                lenderTool.Availability = false;

                if( transaction.BorowerToolId  != null)
                {
                    var borrowerTool = uow.Tools.GetById( transaction.BorowerToolId.Value );
                    borrowerTool.Availability = false;
                }
                

                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }

        public WResult DeclineOffert(long offertId, long userId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var offert = uow.Offerts.GetById( offertId );
                if ( offert == null )
                {
                    return new WResult( ValidationStatus.Failed, "Offert does not exist" );
                }

                uow.Offerts.Remove( offert );
                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }

        public WResult<OffertIndexModel> GetUserSubmittedOfferts(long userId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var offerts = uow.Offerts.GetSentOfferts( userId );
                var SentOfferts = new OffertIndexModel
                {
                    Filters = null,
                    Offerts = OffertMapper.Default.Map<List<OffertInfoModel>>( offerts )
                };
                uow.Complete();

                return new WResult<OffertIndexModel>( ValidationStatus.Succeded, errors: null, data: SentOfferts );
            }
        }

        public WResult<OffertIndexModel> GetUserRecievedOfferts( long userId )
        {
            using ( var uow = new UnitOfWork() )
            {
                var offerts = uow.Offerts.GetRecievedOfferts( userId );
                var recievedOfferts = new OffertIndexModel
                {
                    Filters = null,
                    Offerts = OffertMapper.Default.Map<List<OffertInfoModel>>( offerts )
                };
                uow.Complete();

                return new WResult<OffertIndexModel>( ValidationStatus.Succeded, errors: null, data: recievedOfferts );
            }

        }

        public WResult<OffertModel> GetOffert( long offertId )
        {
            using ( var uow = new UnitOfWork() )
            {
                var offert = uow.Offerts.GetById( offertId );
                if( offert == null )
                {
                    return new WResult<OffertModel>( ValidationStatus.Failed, "Offert does not exist" );
                }

                var offertModel = OffertMapper.Default.Map<OffertModel>( offert );
                uow.Complete();

                return new WResult<OffertModel>( ValidationStatus.Succeded, errors: null, data: offertModel );
            }
        }

    }
}
