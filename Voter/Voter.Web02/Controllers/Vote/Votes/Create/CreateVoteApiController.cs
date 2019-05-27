using System.Web.Http;
using Voter.Web.Controllers.Vote.Votes.Create;
using Voter.Web.Controllers.Common;
using Voter.Web.Mvc.Common;

namespace Voter.Web.Controllers.Vote.Votes.Api
{
    public partial class VoteController : BaseApiController
    {
        public IHttpActionResult Create(CreateVoteModel model)
        {
            //var data = new CreateVoteHandler(_voteService).Handle(model);
            //return Ok();

            return AsResult(Handler.Get<CreateVoteHandler>().Handle(model));
        }
    }
}