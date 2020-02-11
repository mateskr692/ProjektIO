using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Filters;

namespace Data.DAL
{
    public class RequestRepository : BaseRepository<Request, RequestFilters, RequestSorting>
    {
        public RequestRepository( DbContext context ) : base( context )
        {
        }

        public override IDictionary<long, string> GetDictionary()
        {
            throw new NotImplementedException();
        }

        public override IDictionary<long, string> GetFilteredDictionary( RequestFilters filters )
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Request> GetPage( RequestFilters filters )
        {
            throw new NotImplementedException();
        }
    }
}
