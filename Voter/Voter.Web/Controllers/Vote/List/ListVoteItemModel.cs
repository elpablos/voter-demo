using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voter.Web.Controllers.Vote.List
{
    public class ListVoteItemModel
    {
        public Guid Id { get; internal set; }
        public string DisplayName { get; internal set; }
        public int Count { get; internal set; }
    }
}