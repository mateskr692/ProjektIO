using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Buisness.Contracts;
using Buisness.Contracts.Models;
using Buisness.Core.Mappers;
using Common.Enums;
using Common.Filters;
using Data.DAL;

namespace Buisness.Core.Services
{
    public class ToolService
    {

        private static readonly string ToolNotExistsMessage = "Tool with given Id does not exist";

        //Get user tools
        public WResult<ToolIndexModel> GetUserTools(ToolFilters filters, long userId)
        {
            using (var uow = new UnitOfWork())
            {
                var tools = uow.Tools.GetUserPage(filters, userId);

                var toolPage = new ToolIndexModel()
                {
                    Tools = ToolsMapper.Default.Map<List<ToolInfoModel>>(tools),
                    Filters = filters
                };

                uow.Complete();
                return new WResult<ToolIndexModel>(ValidationStatus.Succeded, errors: null, toolPage);
            }
        }

        //AddUserTool
        public WResult AddUserTool(ToolModel toolModel, long userId)
        {

            using (var uow = new UnitOfWork())
            {

                var newTool = ToolsMapper.Default.Map<Tool>(toolModel);
                newTool.UserId = userId;
                uow.Tools.Add(newTool);
                uow.Complete();
            }

            return new WResult(ValidationStatus.Succeded);

        }

        public WResult Delete(long id)
        {
            using (var uow = new UnitOfWork())
            {
                var toolModel = uow.Tools.GetById( id );
                if(toolModel == null)
                {
                    //todo
                }

                uow.Tools.Remove(toolModel);
                uow.Complete();
            }

            return new WResult(ValidationStatus.Succeded);

        }

 
        public WResult Update(ToolModel toolModel)
        {
            using (var uow = new UnitOfWork())
            {
                var tool = uow.Tools.GetById(toolModel.Id);
                if (tool == null)
                {
                    return new WResult(ValidationStatus.Failed, ToolNotExistsMessage);
                }

                ToolsMapper.Default.Map(toolModel, tool);

                uow.Complete();
                return new WResult(ValidationStatus.Succeded);
            }
        }

        public WResult<ToolModel> GetById(long id)
        {
            using (var uow = new UnitOfWork())
            {
                var tool = uow.Tools.GetById(id);
                if (tool == null)
                {
                    return new WResult<ToolModel>(ValidationStatus.Failed, ToolNotExistsMessage);
                }

                var toolModel = ToolsMapper.Default.Map<ToolModel>(tool);
                uow.Complete();
                return new WResult<ToolModel>(ValidationStatus.Succeded, errors: null, toolModel);
            }
        }

        public WResult<ToolIndexModel> GetCommunityTools( ToolFilters filters, long communityId )
        {
            using ( var uow = new UnitOfWork() )
            {
                var tools = uow.Communities.GetCommunityTools( filters, communityId );

                var toolPage = new ToolIndexModel()
                {
                    Tools = ToolsMapper.Default.Map<List<ToolInfoModel>>( tools ),
                    Filters = filters
                };

                uow.Complete();
                return new WResult<ToolIndexModel>( ValidationStatus.Succeded, errors: null, toolPage );
            }
        }
    }
}
