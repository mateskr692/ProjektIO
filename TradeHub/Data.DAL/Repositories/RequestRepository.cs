using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
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


        public Request InvitationExists(long userId, long communityId)
        {
            return this.dbSet.Where( it => it.UserId == userId && it.CommunityId == communityId && it.Type == (int)RequestType.Invitation ).SingleOrDefault();
        }

        public Request RequestExsits(long userId, long communityId)
        {
            return this.dbSet.Where( it => it.UserId == userId && it.CommunityId == communityId && it.Type == (int)RequestType.Request ).SingleOrDefault();
        }

        public IEnumerable<Request> GetUserInvitations(long userId)
        {
            return this.dbSet.Where( it => it.UserId == userId && it.Type == (int)RequestType.Invitation );
        }

        public IEnumerable<Request> GetCommunityJoinRequests(long communityId)
        {
            return this.dbSet.Where( it => it.CommunityId == communityId && it.Type == (int)RequestType.Request );
        }
    }
}
