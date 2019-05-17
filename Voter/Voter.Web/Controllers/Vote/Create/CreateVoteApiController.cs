using System.Web.Http;
using Voter.Web.Controllers.Vote.Create;
using Voter.Web.Modules.Common;
using Voter.Web.Mvc.Common;

namespace Voter.Web.Controllers.Vote.Api
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