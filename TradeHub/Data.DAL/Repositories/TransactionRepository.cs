using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Filters;

namespace Data.DAL
{
    public class TransactionRepository : BaseRepository<Transaction, TransactionFilters, TransactionSorting>
    {
        public TransactionRepository( DbContext context ) : base( context )
        {
        }

        public override IDictionary<long, string> GetDictionary()
        {
            throw new NotImplementedException();
        }

        public override IDictionary<long, string> GetFilteredDictionary( TransactionFilters filters )
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Transaction> GetPage( TransactionFilters filters )
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Transaction> GetUserLendingTransactions(long userId)
        {
            return this.dbSet.Where( it => it.LenderId == userId && it.IsFinished == false);
        }

        public IEnumerable<Transaction> GetUserBorrowingTransactions( long userId )
        {
            return this.dbSet.Where( it => it.BorowerId == userId && it.IsFinished == false );
        }

        public int GetUserTotalOpinion( long userId )
        {
            var borrowingTransactions = this.dbSet.Where( it => it.BorowerId == userId && it.IsFinished == true );
            var borrowingScore = borrowingTransactions != null && borrowingTransactions.Count() > 0 ?
                borrowingTransactions.Sum( s => s.LenderOpinion ) : 0;

            var lendingTransactions = this.dbSet.Where( it => it.LenderId == userId && it.IsFinished == true );
            var lendingScore = lendingTransactions != null && lendingTransactions.Count() > 0 ?
                lendingTransactions.Sum( s => s.BorrowerOpinion ) : 0;

            return borrowingScore + lendingScore;
        }

        public double GetUserAverageOpinion( long userId)
        {
            var borrowingTransactions = this.dbSet.Where( it => it.BorowerId == userId && it.IsFinished == true );
            var borrowingScore = borrowingTransactions != null && borrowingTransactions.Count() > 0 ?
                borrowingTransactions.Average( s => s.LenderOpinion ) : 0.0;

            var lendingTransactions = this.dbSet.Where( it => it.LenderId == userId && it.IsFinished == true );
            var lendingScore = lendingTransactions != null && lendingTransactions.Count() > 0 ?
                lendingTransactions.Average( s => s.BorrowerOpinion ) : 0.0;

            return ( borrowingScore + lendingScore ) / 2;
        }

    }
}
