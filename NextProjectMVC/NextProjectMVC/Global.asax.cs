using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PerpetuumSoft.Knockout;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using NextProjectMVC.Core;
using MvcContrib.CommandProcessor.Commands;

namespace NextProjectMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterTypeResolver();
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.DefaultBinder = new KnockoutModelBinder();
        }

        private void RegisterTypeResolver()
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(assembly);
            builder.RegisterType<Bus>().As<IBus>().InstancePerDependency();
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(Command<>)).InstancePerHttpRequest();

            var container = builder.Build();
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
        }
    }
}