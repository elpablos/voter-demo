//using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Voter.Core.Domains.Services.Vote.Votes;
using Voter.Web.Mvc.Results;
//using Voter.Core.Services.Votes;

namespace Voter.Web.Controllers.Vote.Votes.Create
{
    public class CreateVoteHandler : IModelHandler<CreateVoteModel>
    {
        private IVoteService _voteService;

        public CreateVoteHandler(IVoteService voteService)
        {
            _voteService = voteService;
        }

        //public CreateVoteModel Handle(CreateVoteModel model)
        //{

        //    var result = _voteService.Create(new CreateVoteInputModel
        //    {
        //        Result = model.Result,
        //        UID = model.Uid,
        //    });

        //    return model;
        //}

        public ModelHandlerResult Handle(CreateVoteModel model)
        {
            var result = _voteService.Create(new CreateVoteInputModel
            {
                Result = model.Result,
                UID = model.Uid,
            });

            //var context = GlobalHost.ConnectionManager.GetHubContext<Hubs.VoterHub>();
            //context.Clients.All.broadcastMessage(model.Uid.ToString(), model.Result.HasValue ? (model.Result.Value ? "Yes" : "No") : "Don't know");

            return new ModelHandlerResult()
            {
                Message = result.IsSuccess ? Resources.Dictionary.Global_Edit_SuccessNotification : null,
                Data = model,
                Exception = result.Exception,
                ValidationMessages = result.ValidationMessages
            };
        }
    }
}