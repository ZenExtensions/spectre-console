using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using ZenExtensions.Spectre.Console.Configuration;
using ZenExtensions.Spectre.Console.DependencyInjection;
using ZenExtensions.Spectre.Console.Extensions;
using ZenExtensions.Spectre.Console.Integration;

namespace ZenExtensions.Spectre.Console
{
    public class CliHost
    {
        private readonly string appName;
        public CliHost(string appName)
        {
            this.appName = appName;
        }
        public CliHost Configure(Action<TerminalConfiguration> config)
        {
            TerminalConfiguration.Configure(config);
            return this;
        }
        public Task<int> RunAsync<TStartup>(string[] args)
            where TStartup : BaseStartup, new()
        {
            var startup = new TStartup();
            var registrar = getTypeRegistrarFromStartup(startup, this.appName, args);
            var app = new CommandApp(registrar);
            app.Configure(options =>
            {
                startup.ConfigureCommands(in options);
                options.SetApplicationName(this.appName);
                options.CaseSensitivity(CaseSensitivity.None);
                options.ValidateExamples();
            });
            return app.RunAsync(args);
        }

        public Task<int> RunWithMainCommandAsync<TStartup, TCommand>(string[] args)
            where TStartup : BaseStartup, new()
            where TCommand : class, IZenCommand
        {
            var startup = new TStartup();
            var registrar = getTypeRegistrarFromStartup(startup, this.appName, args);
            var app = new CommandApp<TCommand>(registrar);
            app.Configure(options =>
            {
                startup.ConfigureCommands(in options);
                options.SetApplicationName(this.appName);
                options.CaseSensitivity(CaseSensitivity.None);
                options.ValidateExamples();
            });
            return app.RunAsync(args);
        }

        private static TypeRegistrar getTypeRegistrarFromStartup<TStartup>(TStartup startup, string appName, string[] args)
            where TStartup : BaseStartup
        {
            var services = startup.GetServiceCollectionFrom(appName: appName, args);
            services.AddSingleton<ZenCommandSettings>();
            var registrar = new TypeRegistrar(services);
            return registrar;
        }
    }
}