using Voter.Core.Domains.Services.Vote.Campaigns;
using Voter.Web.Mvc.LoggedUsers;
using Voter.Web.Mvc.Results;
using System;
using System.Linq;

namespace Voter.Web.Controllers.Vote.Campaigns.DetailHeader
{
    /// <summary>
    /// 
    /// Builder pro entitu - Kampaně
    /// </summary>
    public class DetailHeaderCampaignBuilder : IModelBuilder<DetailHeaderCampaignModel, int>
    {
        private readonly ILoggedUser _loggedUser;
        private readonly ICampaignService _CampaignService;
        /*
        */

        public DetailHeaderCampaignBuilder(ILoggedUser loggedUser, ICampaignService CampaignService)
        /*
        */
        {
            _loggedUser = loggedUser;
            _CampaignService = CampaignService;
            /*
            */
        }

        public ModelBuilderResult<DetailHeaderCampaignModel> Build(int id)
        {
            var data = new DetailHeaderCampaignModel();
            var result = _CampaignService.DetailHeader(new DetailHeaderCampaignInputModel
            {
                ID_Login = _loggedUser.ID_Login,
                ID = id,
            });

            data.Id = result.Data.ID;
            data.DisplayName = result.Data.DisplayName;
            data.Description = result.Data.Description;
            data.Question = result.Data.Question;
            data.ID_Question = result.Data.ID_Question;

            return Build(data);
        }

        public ModelBuilderResult<DetailHeaderCampaignModel> Build(DetailHeaderCampaignModel model)
        {
            /*

            */
            return this.Success(model);
        }
    }
}

