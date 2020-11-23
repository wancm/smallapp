using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onecm.Caching;
using Onecm.Global;
using Onecm.Global.Caching;
using Onecm.Global.Sessions;
using Onecm.Sessions;
using System;
using System.IO;

namespace Onecm.App
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public static IContainer ApplicationContainer { get; private set; }

        public static IServiceProvider ConfigureServices(IServiceCollection services, IAppSettings appSettings)
        {
            // Build configuration
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            services.AddMemoryCache();

            // Autofac
            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder
                .RegisterInstance(appSettings)
                .SingleInstance();

            builder.RegisterType<MemoryCacheService>()
                .As<ICacheService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SessionTokenService>()
                .As<ISessionTokenService>()
                .InstancePerLifetimeScope();

            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }
    }
}