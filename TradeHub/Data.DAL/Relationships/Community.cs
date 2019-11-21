using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class Community
    {
        public virtual ICollection<User> BannedUsers
        {
            get => this.Users;
            set => this.Users = value;
        }

        public virtual ICollection<User> CommunityUsers
        {
            get => this.Users1;
            set => this.Users1 = value;
        }

    }
}
