using Voter.Web.Modules.Common;
using Voter.Web.Modules.Vote.Campaigns.Detail;
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
        /// <param name="id">Id</param>
        /// <returns>View</returns>
        public ActionResult Detail(int id)
        {
            return AsView(Handler.Get<DetailCampaignBuilder>().Build(id));
        }

    }
}

