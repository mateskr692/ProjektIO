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
        public WResult AddCommunity(CommunityModel communityModel)
        {
            using (var uow = new UnitOfWork())
            {
                var newCommunity = CommunitiesMapper.Default.Map<Community>(communityModel);
                uow.Communities.Add(newCommunity);

                uow.Complete();
                return new WResult(ValidationStatus.Succeded);
            }
        }

        //GetPaged               (Read)
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

        //GetById
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

        //GetUserCommunities
        public WResult<CommunityIndexModel> GetUserCommunities( UserFilters filters, long UserId)
        {
            //TODO: FILTERING
            using (var uow = new UnitOfWork())
            {
                var user = uow.Users.GetById(UserId);
                if (user == null)
                {
                    return new WResult<CommunityIndexModel>(ValidationStatus.Failed, UserNotExistsMessage);
                }

                var userCommunities = user.MemberCommunities.ToArray();
                var communityIndexModel = new CommunityIndexModel();

                communityIndexModel.Communities = CommunitiesMapper.Default.Map<List<CommunityInfoModel>>(userCommunities);

                uow.Complete();
                return new WResult<CommunityIndexModel>(ValidationStatus.Succeded, errors: null, communityIndexModel);
            }
        }

        //GetDictionary
        //GetFilteredDictionary

        //Update                 (Update)

        //Delete                 (Delete)

        public WResult AddUserToCommunity(long CommunityId, long UserId)
        {
            using (var uow = new UnitOfWork())
            {
                var community = uow.Communities.GetById(CommunityId);
                var user = uow.Users.GetById(UserId);

                if (community == null)
                {
                    return new WResult<CommunityModel>(ValidationStatus.Failed, CommunityNotExistsMessage);
                }

                if (user == null)
                {
                    return new WResult<CommunityModel>(ValidationStatus.Failed, UserNotExistsMessage);
                }
                
                if (uow.Communities.IsUserInCommunity(CommunityId, UserId))
                {
                    return new WResult<CommunityModel>(ValidationStatus.Failed, alreadyMemberMessage);
                }

                community.CommunityUsers.Add(user);

                uow.Complete();
                return new WResult(ValidationStatus.Succeded);
            }
        }

        public WResult RemoveUserFromCommunity(long CommunityId, long UserId)
        {
            using (var uow = new UnitOfWork())
            {
                var community = uow.Communities.GetById(CommunityId);
                var user = uow.Users.GetById(UserId);

                if (community == null)
                {
                    return new WResult<CommunityModel>(ValidationStatus.Failed, CommunityNotExistsMessage);
                }

                if (user == null)
                {
                    return new WResult<CommunityModel>(ValidationStatus.Failed, UserNotExistsMessage);
                }

                if (!uow.Communities.IsUserInCommunity(CommunityId, UserId))
                {
                    return new WResult<CommunityModel>(ValidationStatus.Failed, notYetMemberMessage);
                }

                community.CommunityUsers.Remove(user);

                uow.Complete();
                return new WResult(ValidationStatus.Succeded);
            }
        }

    }
}
