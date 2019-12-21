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

        //CRUDowe operacje: 
        //Add                    (Create)

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

        //GetDictionary
        //GetFilteredDictionary

        //Update                 (Update)

        //Delete                 (Delete)


    }
}
