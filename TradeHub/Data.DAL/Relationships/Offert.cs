using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class Offert
    {
        public virtual Tool ReceiverTool
        {
            get => this.Tool;
            set => this.Tool = value;
        }

        public virtual Tool SenderTool
        {
            get => this.Tool1;
            set => this.Tool1 = value;
        }

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
