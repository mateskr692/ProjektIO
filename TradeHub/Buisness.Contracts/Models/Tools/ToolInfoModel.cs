using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    public class ToolInfoModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Quality { get; set; }
        public bool Avaibility { get; set; }
        public int Visibility { get; set; }
    }
}
