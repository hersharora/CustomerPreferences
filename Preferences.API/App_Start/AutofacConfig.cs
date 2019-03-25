using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Preferences.API.Services;
using Preferences.Data.Context;
using Preferences.Data.Pattern;
using Preferences.Data.Repository;

namespace Preferences.API.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //todo: change this so that the components are not registered manually one by one.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<PreferenceContext>().As<DbContext>().InstancePerRequest();

            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterGeneric(typeof(EntityBaseRepository<>)).As(typeof(IEntityBaseRepository<>)).InstancePerRequest();

            builder.RegisterType<PreferenceRepository>().As<IPreferenceRepository>().InstancePerRequest();

            builder.RegisterType<CustomerPreferenceService>().As<ICustomerPreferenceService>().InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}