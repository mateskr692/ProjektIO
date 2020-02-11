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
        public QualityType Quality { get; set; } = QualityType.Regular;
        public AvailabilityType Availability { get; set; } = AvailabilityType.Available;
        public VisibilityType Visibility { get; set; } = VisibilityType.Public;
        public long UserId { get; set; }

        public List<ToolPictureModel> ToolPictures { get; set; }

    }
}
