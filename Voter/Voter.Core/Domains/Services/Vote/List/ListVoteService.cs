using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voter.Core.Domains.Services.Vote.List;

namespace Voter.Core.Domains.Services.Vote
{
    public partial class VoteService : IVoteService
    {
        public ICollection<ListVoteOutputModel> List(ListVoteInputModel model)
        {

            var random = new Random(DateTime.Now.Millisecond);
            var result = new List<ListVoteOutputModel>();

            result.Add(new ListVoteOutputModel
            {
                Id = Guid.NewGuid(),
                DisplayName = "Yes",
                Count = random.Next(250),
            });

            result.Add(new ListVoteOutputModel
            {
                Id = Guid.NewGuid(),
                DisplayName = "No",
                Count = random.Next(250),
            });

            result.Add(new ListVoteOutputModel
            {
                Id = Guid.NewGuid(),
                DisplayName = "Don't know",
                Count = random.Next(250),
            });
            return result;
        }
    }
}
