using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voter.Core.Domains.Services.Vote;
using Voter.Core.Domains.Services.Vote.Votes;
using Voter.Core.Utils.Results;

namespace Voter.Core.Services.RandomVotes
{
    public class RandomVoteService : IVoteService
    {
        public RandomVoteService()
        {
        }

        public ModelCoreResult<CreateVoteOutputModel> Create(CreateVoteInputModel input)
        {
            throw new NotImplementedException();
        }

        public ModelCoreResult<ICollection<ListVoteOutputModel>> List(ListVoteInputModel input)
        {
            throw new NotImplementedException();
        }

        public ModelCoreResult<ICollection<ListCampaignVoteOutputModel>> ListCampaign(ListCampaignVoteInputModel input)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var result = new ModelCoreResult<ICollection<ListCampaignVoteOutputModel>>();
            var list = new List<ListCampaignVoteOutputModel>();

            string question = "Testovací otázka";

            list.Add(new ListCampaignVoteOutputModel
            {
                ID_Question = 1,
                Question = question,
                DisplayName = "Yes",
                Count = random.Next(250),
            });

            list.Add(new ListCampaignVoteOutputModel
            {
                ID_Question = 1,
                Question = question,
                DisplayName = "No",
                Count = random.Next(250),
            });

            list.Add(new ListCampaignVoteOutputModel
            {
                ID_Question = 1,
                Question = question,
                DisplayName = "Don't know",
                Count = random.Next(250),
            });

            result.Data = list;
            return result;
        }
    }
}
