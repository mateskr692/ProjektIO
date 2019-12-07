using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class User
    {
        public virtual ICollection<Message> ReceivedMessages
        {
            get => this.Messages;
            set => this.Messages = value;
        }

        public virtual ICollection<Message> SentMessages
        {
            get => this.Messages1;
            set => this.Messages1 = value;
        }

        public virtual ICollection<Offert> ReceivedOfferts
        {
            get => this.Offerts;
            set => this.Offerts = value;
        }

        public virtual ICollection<Offert> SentOfferts
        {
            get => this.Offerts1;
            set => this.Offerts1 = value;
        }

        public virtual ICollection<Transaction> BorrowedTransactions
        {
            get => this.Transactions;
            set => this.Transactions = value;
        }

        public virtual ICollection<Transaction> LendTransactions
        {
            get => this.Transactions1;
            set => this.Transactions1 = value;
        }

        public virtual ICollection<User> BlockedUsers
        {
            get => this.Users1;
            set => this.Users1 = value;
        }

        public virtual ICollection<User> BlockedByUsers
        {
            get => this.Users;
            set => this.Users = value;
        }

        public virtual ICollection<Community> BannedFromCommunities
        {
            get => this.Communities;
            set => this.Communities = value;
        }
        public virtual ICollection<Community> MemberCommunities
        {
            get => this.Communities1;
            set => this.Communities1 = value;
        }
    }
}
