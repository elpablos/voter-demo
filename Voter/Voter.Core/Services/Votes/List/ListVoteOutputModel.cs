using System;

namespace Voter.Core.Services.Votes
{
    public class ListVoteOutputModel
    {
        public Guid Id { get; set; }
        public string DisplayName { get; internal set; }
        public int Count { get; internal set; }
    }
}