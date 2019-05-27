using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Voter.Core.Domains.Services.Vote.Votes;
using Voter.Web.Mvc.Results;

namespace Voter.Web.Controllers.Vote.Votes.List
{
    public class ListVoteBuilder : IModelBuilder<ListVoteModel, ListVoteFilterModel>
    {
        private readonly IVoteService _voteService;

        public ListVoteBuilder(IVoteService voteService)
        {
            _voteService = voteService;
        }

        public ModelBuilderResult<ListVoteModel> Build(ListVoteFilterModel filter)
        {
            var data = new ListVoteModel();
            data.Filter = filter;
            data.Items = _voteService.ListCampaign(new ListCampaignVoteInputModel
            {
                ID_Campaign = filter.ID_Campaign
            }).Data
                .Select(x => new ListVoteItemModel
                {
                    //Id = x.Id,
                    DisplayName = x.DisplayName,
                    Count = x.Count.Value
                }).ToList();

            return this.Success(data);
        }

        //public ListVoteModel Build(ListVoteFilterModel filter)
        //{
        //    var result = new ListVoteModel();
        //    result.Filter = filter;
        //    result.Items = _voteService.ListCampaign(new ListCampaignVoteInputModel
        //    {
        //        ID_Campaign = filter.ID_Campaign
        //    }).Data
        //        .Select(x => new ListVoteItemModel
        //        {
        //            //Id = x.Id,
        //            DisplayName = x.DisplayName,
        //            Count = x.Count.Value
        //        }).ToList();

        //    return result;
        //}
    }
}