using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Voter.Core.Models;

namespace Voter.Core.Services.Votes
{
    public partial class VoteService : IVoteService
    {
        public CreateVoteOutputModel Create(CreateVoteInputModel model)
        {
            var col = GetCollections();
            col.Add(new VoteModel
            {
                Uid = model.Uid,
                Result = model.Result
            });

            return new CreateVoteOutputModel();
        }
    }
}
