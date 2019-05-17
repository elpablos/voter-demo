using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voter.Core.Domains.Services.Vote.List
{
    public class ListVoteOutputModel
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public int Count { get; set; }
    }
}
