using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Voter.Core.Domains.Services.Vote.Votes;
using Voter.Core.Models;
using Voter.Core.Utils.Results;

namespace Voter.Core.Domains.Services.Vote
{
    public partial class MemoryVoteService : IVoteService
    {
        public ModelCoreResult<CreateVoteOutputModel> Create(CreateVoteInputModel input)
        {
            var result = new ModelCoreResult<CreateVoteOutputModel>();

            var col = GetCollections();
            col.Add(new VoteModel
            {
                Uid = input.UID,
                Result = input.Result
            });


            return result;
        }
    }
}
