﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Portal.Models
{
    public class CommunityInfoViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
    }
}