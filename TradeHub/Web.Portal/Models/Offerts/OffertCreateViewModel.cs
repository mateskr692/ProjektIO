using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Portal.Models
{
    public class OffertCreateViewModel
    {
        public OffertViewModel OffertModel { get; set; }
        //public ToolIndexViewModel SenderTools { get; set; }

        public IDictionary<long, string> SenderToolsDictionary { get; set; }
        public bool OFfertsSendersTool { get; set; } = false;

        public SelectList SelectListItems
        {
            get => new SelectList( this.SenderToolsDictionary, "Key", "Value" );
        }
        

    }
}