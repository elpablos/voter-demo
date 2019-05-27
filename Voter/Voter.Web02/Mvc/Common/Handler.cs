using System.Web.Mvc;

namespace Voter.Web.Mvc.Common
{
    /// <summary>
    /// Pomocná třída pro vytvoření instance handleru
    /// </summary>
    public static class Handler
    {
        /// <summary>
        /// Vrátí instanci handleru
        /// </summary>
        /// <typeparam name="THandler"></typeparam>
        /// <returns></returns>
        public static THandler Get<THandler>() where THandler : class
        {
            return DependencyResolver.Current.GetService<THandler>();
        }
    }
}