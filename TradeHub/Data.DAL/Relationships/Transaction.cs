using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class Transaction
    {
        public virtual Tool BorrowerTool
        {
            get => this.Tool;
            set => this.Tool = value;
        }

        public virtual Tool SenderTool
        {
            get => this.Tool1;
            set => this.Tool1 = value;
        }

        public virtual User Borower
        {
            get => this.User;
            set => this.User = value;
        }

        public virtual User Lender
        {
            get => this.User1;
            set => this.User1 = value;
        }
    }
}
