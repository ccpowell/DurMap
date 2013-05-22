using System.Web.Http;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace DurMap.Site
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            // handle MVC4 controllers
            DependencyResolver.SetResolver(new Unity.Mvc4.UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();      
            container.RegisterType<Data.Repository>();

            return container;
        }
    }
}