using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voter.Web.Controllers.Vote.Votes.List
{
    public class ListVoteModel
    {
        public ListVoteFilterModel Filter { get; set; }
        public ICollection<ListVoteItemModel> Items { get; set; }

        public ListVoteModel()
        {
            Filter = new ListVoteFilterModel();
            Items = new List<ListVoteItemModel>();
        }
    }
}