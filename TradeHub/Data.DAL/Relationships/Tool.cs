using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class Tool
    {
        
        public virtual ICollection<Offert> ReceivedOfferts
        {
            get => this.Offerts;
            set => this.Offerts = value;
        }
        
        public virtual ICollection<Offert> SendOfferts
        {
            get => this.Offerts1;
            set => this.Offerts1 = value;
        }
        
        public virtual ICollection<Transaction> BorrowedTransactions
        {
            get => this.Transactions;
            set => this.Transactions = value;
        }
        
        public virtual ICollection<Transaction> LentTransactions
        {
            get => this.Transactions1;
            set => this.Transactions1 = value;
        }
        
        public virtual ICollection<Community> BannedCommunities
        {
            get => this.Communities;
            set => this.Communities = value;
        }
    }
}
