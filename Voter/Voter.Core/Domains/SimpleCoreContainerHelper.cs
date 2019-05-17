using SimpleInjector;
using Voter.Core.Domains.Services.Vote.Campaigns;
using Voter.Core.Domains.Services.Vote.Questions;
using Voter.Core.Domains.Services.Vote.Votes;

namespace Voter.Core.Domains
{
    /// <summary>
    /// Pomocna trida pro registraci rozhrani vs implementace pro DLL Core
    /// </summary>
    public static class SimpleCoreContainerHelper
    {
        /// <summary>
        /// Naplnění kontajneru - registrace implementací z DLL Core
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static Container Build(Container container)
        {
            var defaultLifestyle = Lifestyle.Scoped;

            container.Register<ICampaignService, CampaignService>(defaultLifestyle);
            container.Register<IQuestionService, QuestionService>(defaultLifestyle);
            container.Register<IVoteService, VoteService>(defaultLifestyle);


            return container;
        }
    }
}
