using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voter.Web.Controllers.Vote.Votes.List;
using Voter.Web.Controllers.Common;
using Voter.Web.Mvc.Common;

namespace Voter.Web.Controllers.Vote.Votes
{
    public partial class VoteController : BaseController
    {
        public ActionResult Index(ListVoteFilterModel model)
        {
            //var data = new ListVoteBuilder(_voteService).Build(model);
            //return AsView(data);

            return AsView(Handler.Get<ListVoteBuilder>().Build(model));
        }
    }
}