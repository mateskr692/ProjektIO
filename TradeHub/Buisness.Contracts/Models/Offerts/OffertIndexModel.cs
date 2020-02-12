using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Filters;

namespace Buisness.Contracts.Models
{
    public class OffertIndexModel
    {
        public OffertFilters Filters { get; set; }
        public List<OffertInfoModel> Offerts { get; set; }
    }
}
