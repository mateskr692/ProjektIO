using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Filters;

namespace Buisness.Contracts.Models
{
    public class RequestIndexModel
    {
        public RequestFilters Filters { get; set; }
        public List<RequestInfoModel> Requests { get; set; }
    }
}
