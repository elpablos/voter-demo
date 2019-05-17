using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using NLog;
using System.Web.Optimization;
using SimpleInjector.Integration.Web.Mvc;
using Voter.Web.Mvc;

namespace Voter.Web
{
    public class Global : HttpApplication
    {
        /// <summary>
        /// Logger
        /// </summary>
        public Logger Log { get; private set; }

        public Global()
        {
            Log = LogManager.GetLogger(GetType().FullName);
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // JS a CSS bundly
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // SimpleWebInjector
            var container = SimpleInjectorContainer.Build(GlobalConfiguration.Configuration);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            Log.Info("App start");
        }
    }
}