using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Buisness.Contracts.Models
{
    public class ToolModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Quality { get; set; }
        public bool Avaibility { get; set; }
        public VisibilityType Visibility { get; set; }
        public long UserId { get; set; }

    }
}
