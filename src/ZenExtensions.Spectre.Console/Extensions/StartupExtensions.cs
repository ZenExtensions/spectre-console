using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using ZenExtensions.Spectre.Console.DependencyInjection;

namespace ZenExtensions.Spectre.Console.Extensions
{
    internal static class StartupExtensions
    {
        public static IServiceCollection GetServiceCollectionFrom<TStartup>(this TStartup startup, string[]? args = null) where TStartup : BaseStartup
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddCommandLine(args ?? new string[0])
                .AddEnvironmentVariables();
            return startup.GetServiceCollectionFrom(configurationBuilder);
        }

        internal static IServiceCollection GetServiceCollectionFrom<TStartup>(this TStartup startup, IConfigurationBuilder configurationBuilder) where TStartup : BaseStartup
        {
            var services = new ServiceCollection();
            var hostingEnvironment = configurationBuilder.Build()
                .GetHostingEnvironment();
            startup.ConfigureAppConfiguration(configurationBuilder, hostingEnvironment);
            var configuration = configurationBuilder.Build();
            services.AddSingleton<IConfigurationRoot>(configurationBuilder.Build());
            services.AddHostingEnvironment(hostingEnvironment);
            startup.ConfigureServices(services, configuration, hostingEnvironment);
            return services;
        }

        

        internal static IServiceCollection GetServiceCollectionFrom<TStartup>(this TStartup startup, string appName, string[]? args = null) where TStartup : BaseStartup
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { HostDefaults.ApplicationKey, appName },
            })
                .AddCommandLine(args ?? new string[0])
                .AddEnvironmentVariables();
            return startup.GetServiceCollectionFrom(configurationBuilder);
        }

        internal static IServiceCollection AddHostingEnvironment(this IServiceCollection services, HostingEnvironment hostingEnvironment)
        {
            services.AddSingleton<IHostEnvironment>(hostingEnvironment);
            return services;
        }
    }
}