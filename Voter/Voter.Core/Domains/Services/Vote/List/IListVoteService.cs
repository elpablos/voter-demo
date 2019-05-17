using System.Collections.Generic;
using Voter.Core.Domains.Services.Vote.List;

namespace Voter.Core.Domains.Services.Vote
{
    public partial interface IVoteService
    {
        ICollection<ListVoteOutputModel> List(ListVoteInputModel model);
    }
}