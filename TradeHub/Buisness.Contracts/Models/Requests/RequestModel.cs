using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Buisness.Contracts.Models.Requests
{
    public class RequestModel
    {
        public long Id { get; set; }

        public RequestType Type { get; set; }
        public long UserId { get; set; }
        public long CommunityId { get; set; }
    }
}
