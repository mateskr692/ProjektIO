using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
   public class CommunityIndexModel
    {
        public CommunityFilters Filters { get; set; }

        public List<CommunityInfoModel> Communities { get; set; }
    }
}
