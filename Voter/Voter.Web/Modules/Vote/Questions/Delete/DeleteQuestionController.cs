using Voter.Web.Modules.Common;
using Voter.Web.Modules.Vote.Questions.Delete;
using Voter.Web.Mvc.Common;
using System.Web.Mvc;

namespace Voter.Web.Modules.Vote.Questions
{
    /// <summary>
    /// Implementace kontroleru pro entitu - Otázky
    /// </summary>
    public partial class QuestionController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Delete(int id)
        {
            return AsView(Handler.Get<DeleteQuestionHandler>().Handle(id), RedirectToAction("Index", "Question"));
        }

    }
}

