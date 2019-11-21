using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class Message
    {
        public virtual User Receiver
        {
            get => this.User;
            set => this.User = value;
        }

        public virtual User Sender
        {
            get => this.User1;
            set => this.User1 = value;
        }
    }
}
