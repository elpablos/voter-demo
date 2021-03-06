using Voter.Core.Domains.Services.Vote.Campaigns;
using Voter.Web.Mvc.LoggedUsers;
using Voter.Web.Mvc.Results;
using System;
using System.Linq;

namespace Voter.Web.Controllers.Vote.Campaigns.List
{
    /// <summary>
    /// 
    /// Builder pro entitu - Kampaně
    /// </summary>
    public class ListCampaignBuilder : IModelBuilder<ListCampaignModel, ListCampaignFilterModel>
    {
        private readonly ILoggedUser _loggedUser;
        private readonly ICampaignService _CampaignService;

        public ListCampaignBuilder(ILoggedUser loggedUser, ICampaignService CampaignService)
        {
            _loggedUser = loggedUser;
            _CampaignService = CampaignService;
        }

        public ModelBuilderResult<ListCampaignModel> Build(ListCampaignFilterModel filter)
        {
            var data = new ListCampaignModel();
            var result = _CampaignService.List(new ListCampaignInputModel
            {
                ID_Login = _loggedUser.ID_Login,
                Top = filter.Top,
                ID = filter.Id,
                DisplayName = filter.DisplayName,
            });
            data.Items = result.Data.Select(x => new ListCampaignItemModel
            {
                Id = x.ID,
                DisplayName = x.DisplayName,
                IsActive = x.IsActive,
                Description = x.Description,
            }).ToList();

            return this.Success(data);
        }
    }
}

