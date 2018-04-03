using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;
//using HospitalAPI.DataAccessLayer;
//using HospitalAPI.BusinessLayer;
using Unity.Lifetime;
using HospitalAPI.DependencyResolver;

namespace HospitalAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            IUnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            //container.RegisterType<ITestService, TestService>();


            //a singleton instance which is scoped to the lifetime of the container
            // container.RegisterType<IDataAccessService, DataAccessService>(new ContainerControlledLifetimeManager());

            //container.RegisterType<IBusinessService, BusinessService>().RegisterType<IDataAccessService, DataAccessService>(new ContainerControlledLifetimeManager()); ;

            //Use DependencyResolver (MEF) to initialize components
            Resolver.LoadContainer(container, ".\\bin", "HospitalAPI.dll");
            Resolver.LoadContainer(container, ".\\bin", "BusinessLayer.dll");
            Resolver.LoadContainer(container, ".\\bin", "DataAccessLayer.dll");

            //System.Web.Mvc.DependencyResolver.SetResolver(new Unity.WebApi.UnityDependencyResolver(container));

            // register dependency resolver for HospitalAPI
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}