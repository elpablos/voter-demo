using Voter.Web.Modules.Common;
using Voter.Web.Modules.Vote.Campaigns.Delete;
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
        /// 
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Delete(int id)
        {
            return AsView(Handler.Get<DeleteCampaignHandler>().Handle(id), RedirectToAction("Index", "Campaign"));
        }

    }
}

