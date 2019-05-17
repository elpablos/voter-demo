using Voter.Web.Modules.Common;
using Voter.Web.Modules.Vote.Questions.List;
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
        /// <param name="model">filtr</param>
        /// <returns>View</returns>
        public ActionResult Index(ListQuestionFilterModel model)
        {
            return AsView(Handler.Get<ListQuestionBuilder>().Build(model));
        }
    }
}

