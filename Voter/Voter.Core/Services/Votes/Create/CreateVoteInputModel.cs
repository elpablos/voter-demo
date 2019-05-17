using System;

namespace Voter.Core.Services.Votes
{
    public class CreateVoteInputModel
    {
        public Guid Uid { get; set; }

        public bool? Result { get; set; }
    }
}