using Voter.Core.Domains.Services.Vote.Questions;
using Voter.Web.Mvc.LoggedUsers;
using Voter.Web.Mvc.Results;
using System;

namespace Voter.Web.Controllers.Vote.Questions.Edit
{
    /// <summary>
    /// 
    /// Builder pro entitu - Otázky
    /// </summary>
    public class EditQuestionHandler : IModelHandler<EditQuestionModel>
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IQuestionService _QuestionService;

        public EditQuestionHandler(ILoggedUser loggedUser, IQuestionService QuestionService)
        {
            _loggedUser = loggedUser;
            _QuestionService = QuestionService;
        }

        public ModelHandlerResult Handle(EditQuestionModel model)
        {
            var data = new EditQuestionModel();
            var result = _QuestionService.Edit(new EditQuestionInputModel
            {
                ID_Login = _loggedUser.ID_Login,
                ID = model.Id,
                DisplayName = model.DisplayName,
                Description = model.Description,
            });

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

