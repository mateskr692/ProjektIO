using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    public class ToolPictureModel
    {
        public long Id { get; set; }
        public byte[] PictureData { get; set; }
        public long ToolId { get; set; }
    }
}
