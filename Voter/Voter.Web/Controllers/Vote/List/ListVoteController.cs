using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voter.Web.Controllers.Vote.List;
using Voter.Web.Modules.Common;
using Voter.Web.Mvc.Common;

namespace Voter.Web.Controllers.Vote
{
    public partial class VoteController : BaseController
    {
        public ActionResult Index(ListVoteFilterModel model)
        {
            //var data = new ListVoteBuilder(_voteService).Build(model);
            //return View(data);

            return AsView(Handler.Get<ListVoteBuilder>().Build(model));
        }
    }
}