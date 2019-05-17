using SimpleInjector;
using Voter.Web.Mvc.LoggedUsers;

namespace Voter.Web.Mvc
{
    public static class SimpleWebContainerHelper
    {
        /// <summary>
        /// Naplnění kontajneru - registrace implementací z DLL Web
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static void Build(Container container)
        {
            var defaultLifestyle = Lifestyle.Scoped;

            container.Register<ILoggedUser, LoggedUser>(defaultLifestyle);
        }
    }
}