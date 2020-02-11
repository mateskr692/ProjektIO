using Buisness.Contracts;
using Common.Enums;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Contracts.Models;
using Common.Filters;
using Buisness.Core.Mappers;

namespace Buisness.Core.Services
{
    public class CommunityService
    {
        private static readonly string CommunityNotExistsMessage = "Such community does not exist";
        private static readonly string UserNotExistsMessage = "Such user does not exist";
        private static readonly string alreadyMemberMessage = "You have already joined this community";
        private static readonly string notYetMemberMessage = "You have not joined this community yet";

        //CRUDowe operacje: 
        //Add                    (Create)
        public WResult AddCommunity(CommunityModel communityModel, long founderUserId)
        {
            using (var uow = new UnitOfWork())
            {
                var founder = uow.Users.GetById( founderUserId );
                if( founder == null )
                {
                    return new WResult( ValidationStatus.Failed, UserNotExistsMessage );
                }

                var newCommunity = CommunitiesMapper.Default.Map<Community>(communityModel);
                newCommunity.CommunityUsers.Add( founder );
                uow.Communities.Add(newCommunity);

                uow.Complete();
                return new WResult(ValidationStatus.Succeded);
            }
        }


        public WResult<CommunityIndexModel> GetPaged(CommunityFilters filters)
        {
            using (var uow = new UnitOfWork())
            {
                var communities = uow.Communities.GetPage(filters);

                var communitiesPage = new CommunityIndexModel()
                {
                    Communities = CommunitiesMapper.Default.Map<List<CommunityInfoModel>>(communities),
                    Filters = filters
                };

                uow.Complete();
                return new WResult<CommunityIndexModel>(ValidationStatus.Succeded, errors: null, communitiesPage);
            }
        }


        public WResult<CommunityModel> GetById(long id)
        {
            using (var uow = new UnitOfWork())
            {
                var community = uow.Communities.GetById(id);
                if (community == null)
                {
                    return new WResult<CommunityModel>(ValidationStatus.Failed, CommunityNotExistsMessage);
                }

                var communityModel = CommunitiesMapper.Default.Map<CommunityModel>(community);
                uow.Complete();

                return new WResult<CommunityModel>(ValidationStatus.Succeded, errors: null, communityModel);
            }
        }

        public WResult<CommunityIndexModel> GetUserCommunities( UserFilters filters, long userId)
        {
            using (var uow = new UnitOfWork())
            {
                var user = uow.Users.GetById(userId);
                if (user == null)
                {
                    return new WResult<CommunityIndexModel>(ValidationStatus.Failed, UserNotExistsMessage);
                }

                var userCommunities = user.MemberCommunities.ToArray();
                var communityIndexModel = new CommunityIndexModel();

                communityIndexModel.Communities = CommunitiesMapper.Default.Map<List<CommunityInfoModel>>(userCommunities);
                uow.Complete();

                return new WResult<CommunityIndexModel>( ValidationStatus.Succeded, errors: null, communityIndexModel );
            }

            
        }


        public WResult RequestToJoin(long communityId, long requesterId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var community = uow.Communities.GetById( communityId );
                var requesterUser = uow.Users.GetById( requesterId );

                if ( community == null )
                {
                    return new WResult( ValidationStatus.Failed, CommunityNotExistsMessage );
                }

                if ( requesterUser == null )
                {
                    return new WResult( ValidationStatus.Failed, UserNotExistsMessage );
                }

                if ( community.CommunityUsers.Contains(requesterUser) )
                {
                    return new WResult( ValidationStatus.Failed, "User is already in this ocmmunity" );
                }

                var joinRequest = new Request
                {
                    Type = (int)RequestType.Request,
                    User = requesterUser,
                    Community = community
                };

                uow.Requests.Add( joinRequest );
                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }

        public WResult InviteToJoin(long communityId, long inviterId, long requesterId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var community = uow.Communities.GetById( communityId );
                var inviterUser = uow.Users.GetById( inviterId );
                var requesterUser = uow.Users.GetById( requesterId );

                if ( community == null )
                {
                    return new WResult( ValidationStatus.Failed, CommunityNotExistsMessage );
                }

                if ( inviterUser == null || requesterUser == null)
                {
                    return new WResult( ValidationStatus.Failed, UserNotExistsMessage );
                }

                if ( !community.CommunityUsers.Contains( inviterUser ) )
                {
                    return new WResult( ValidationStatus.Failed, "User is not in community and can't invite others to join" );
                }

                var joinRequest = new Request
                {
                    Type = (int)RequestType.Invitation,
                    User = requesterUser,
                    Community = community
                };

                uow.Requests.Add( joinRequest );
                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }

        public WResult AcceptRequestToJoin(long requestId, long communityUserId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var request = uow.Requests.GetById( requestId );
                var communityUser = uow.Users.GetById( communityUserId );

                if ( request == null)
                {
                    return new WResult( ValidationStatus.Failed, "Request does not exist" );
                }

                if ( communityUser == null )
                {
                    return new WResult( ValidationStatus.Failed, UserNotExistsMessage );
                }

                if( !request.Community.CommunityUsers.Contains(communityUser) )
                {
                    return new WResult( ValidationStatus.Failed, "User is not in community and can't accept invitations from other users" );
                }

                request.Community.CommunityUsers.Add( request.User );
                uow.Requests.Remove( request );

                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }

        public WResult AcceptInvitationToCommunity(long requestId, long userId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var request = uow.Requests.GetById( requestId );
                var user = uow.Users.GetById( userId );

                if ( request == null )
                {
                    return new WResult( ValidationStatus.Failed, "Request does not exist" );
                }

                if ( user == null )
                {
                    return new WResult( ValidationStatus.Failed, UserNotExistsMessage );
                }

                if ( request.User != user )
                {
                    return new WResult( ValidationStatus.Failed, "User can't accept invitations of other users" );
                }

                request.Community.CommunityUsers.Add( request.User );
                uow.Requests.Remove( request );

                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }

        public WResult RemoveUser(long communityId, long userId)
        {
            using ( var uow = new UnitOfWork() )
            {
                var community = uow.Communities.GetById( communityId );
                var user = uow.Users.GetById( userId );

                if ( community == null )
                {
                    return new WResult( ValidationStatus.Failed, CommunityNotExistsMessage );
                }

                if ( user == null )
                {
                    return new WResult( ValidationStatus.Failed, UserNotExistsMessage );
                }

                if ( uow.Communities.IsUserInCommunity( communityId, userId ) )
                {
                    return new WResult( ValidationStatus.Failed, alreadyMemberMessage );
                }

                community.CommunityUsers.Remove( user );
                if(community.CommunityUsers.Count == 0)
                {
                    uow.Communities.Remove( community );
                }

                uow.Complete();
            }

            return new WResult( ValidationStatus.Succeded );
        }

        public bool IsUserInCommunity(long userId, long communityId)
        {
            using ( var uow = new UnitOfWork() )
            {
                return uow.Communities.IsUserInCommunity( communityId, userId );
            }
        }

        //public WResult BanUser(long communityId, long userId)
        //{

        //}
    }
}
