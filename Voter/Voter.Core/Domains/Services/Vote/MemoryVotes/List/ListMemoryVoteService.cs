using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voter.Core.Domains.Services.Vote.Votes;
using Voter.Core.Utils.Results;

namespace Voter.Core.Domains.Services.Vote
{
    public partial class MemoryVoteService : IVoteService
    {
        public MemoryVoteService()
        {
        }

        /// <summary>
        /// Přehled všech položek - volby
        /// </summary>
        /// <param name="input">vstup</param>
        /// <returns>výstup</returns>
        public ModelCoreResult<ICollection<ListVoteOutputModel>> List(ListVoteInputModel input)
        {
            throw new NotImplementedException();
        }

        public ModelCoreResult<ICollection<ListCampaignVoteOutputModel>> ListCampaign(ListCampaignVoteInputModel input)
        {
            var result = new ModelCoreResult<ICollection<ListCampaignVoteOutputModel>>();
            var list = new List<ListCampaignVoteOutputModel>();

            var col = GetCollections();
            string question = "Testovací otázka";

            list.Add(new ListCampaignVoteOutputModel
            {
                ID_Question = 1,
                Question = question,
                DisplayName = "Yes",
                Count = col.Count(x => x.Result == true)
            });

            list.Add(new ListCampaignVoteOutputModel
            {
                ID_Question = 1,
                Question = question,
                DisplayName = "No",
                Count = col.Count(x => x.Result == false)
            });

            list.Add(new ListCampaignVoteOutputModel
            {
                ID_Question = 1,
                Question = question,
                DisplayName = "Don't know",
                Count = col.Count(x => x.Result == null)
            });

            result.Data = list;
            return result;
        }
    }
}
