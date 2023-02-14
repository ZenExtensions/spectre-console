using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;

namespace ZenExtensions.Spectre.Console
{
    /// <summary>
    /// Startup class to configure dependencies
    /// </summary>
    public abstract class BaseStartup
    {
        /// <summary>
        /// Configure app configuration by adding additional configuration sources
        /// </summary>
        /// <param name="hostingEnvironment">The <see cref="IHostEnvironment"/>.</param>
        /// <param name="configuration">instance of <see cref="IConfigurationBuilder"/></param>
        public virtual void ConfigureAppConfiguration(IConfigurationBuilder configuration, IHostEnvironment hostingEnvironment)
        {
        }
        /// <summary>
        /// Configure application services by adding additional services to the container
        /// </summary>
        /// <param name="services">instance of <see cref="IServiceCollection"/></param>
        /// <param name="configuration">instance of <see cref="IConfigurationBuilder"/></param>
        /// <param name="hostingEnvironment">The <see cref="IHostEnvironment"/>.</param>
        public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment hostingEnvironment);

        public abstract void ConfigureCommands(in IConfigurator configurator);
    }
}