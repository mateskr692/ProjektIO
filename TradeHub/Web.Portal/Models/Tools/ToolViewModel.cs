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
        public QualityType Quality { get; set; } = QualityType.Regular;
        public AvailabilityType Avaibility { get; set; } = AvailabilityType.Available;
        public VisibilityType Visibility { get; set; } = VisibilityType.Public;
        public long UserId { get; set; }

        public List<ToolPictureViewModel> ToolPictures { get; set; }
    }
}