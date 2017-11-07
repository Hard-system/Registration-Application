using ACCDataStore.Repository;
using ACCDataStore.Repository.Impl;
using ACCDataStore.Web.Helpers.ORM;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ACCDataStore.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            // Infrastructure objects
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).AsImplementedInterfaces();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterModule(new AutofacWebTypesModule());

            // Repositories objects
            builder.RegisterType<GenericRepositoryImpl>().As<IGenericRepository>().InstancePerRequest();

            // NHibernate objects
            builder.Register(c => NHibernateHelper.CreateSessionFactory()).As<ISessionFactory>().SingleInstance();
            builder.Register(c => c.Resolve<ISessionFactory>().OpenSession()).InstancePerRequest();

            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();

            IContainer container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}