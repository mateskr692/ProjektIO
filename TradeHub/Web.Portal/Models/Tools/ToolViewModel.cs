using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Enums;

namespace Web.Portal.Models
{
    public class ToolViewModel
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