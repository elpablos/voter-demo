using Voter.Web.Modules.Common;
using Voter.Web.Modules.Vote.Campaigns.ListQuestion;
using Voter.Web.Mvc.Common;
using System.Web.Mvc;

namespace Voter.Web.Modules.Vote.Campaigns
{
    /// <summary>
    /// Implementace kontroleru pro entitu - Kampaně
    /// </summary>
    public partial class CampaignController : BaseController
    {
        /// <summary>
        /// Přehled otázek kampaně
        /// </summary>
        /// <param name="model">filtr</param>
        /// <returns>View</returns>
        public ActionResult Question(ListQuestionCampaignFilterModel model)
        {
            return AsView(Handler.Get<ListQuestionCampaignBuilder>().Build(model));
        }
    }
}

