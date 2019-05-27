using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Voter.Core.Domains.Services.Vote.Votes;
using Voter.Core.Services.RandomVotes;

namespace Voter.Web.Mvc
{
    public static class SimpleInjectorContainer
    {
        /// <summary>
        /// Naplnění kontajneru - registrace závislostí
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static Container Build(HttpConfiguration configuration)
        {
            // inicializace & scope
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // container.RegisterWebApiControllers(configuration);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            // core
            container.Register<IVoteService, RandomVoteService>(Lifestyle.Scoped);

            //Core.Domains.SimpleCoreContainerHelper.Build(container);
            //SimpleCoreContainerHelper.Build(container);
            //Encore.SimpleEncoreContainerHelper.Build(container);

            // web
            SimpleWebContainerHelper.Build(container);

            // verifikace a vraceni kontejneru
            container.Verify(VerificationOption.VerifyOnly);
            return container;
        }
    }
}