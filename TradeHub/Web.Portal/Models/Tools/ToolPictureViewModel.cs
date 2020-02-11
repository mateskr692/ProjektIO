using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Portal.Models
{
    public class ToolPictureViewModel
    {
        public long Id { get; set; }
        public byte[] PictureData { get; set; }
        public long ToolId { get; set; }
    }
}