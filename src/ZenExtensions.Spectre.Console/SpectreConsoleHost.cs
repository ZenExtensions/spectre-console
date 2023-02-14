using System.Threading.Tasks;
using Spectre.Console.Cli;
using Zen.Host;
using ZenExtensions.Spectre.Console.Infrastructure;

namespace ZenExtensions.Spectre.Console
{
    public class SpectreConsoleHost
    {
        private readonly CommandApp app;
        public SpectreConsoleHost(CommandApp app)
        {
            this.app = app;
        }
        public static SpectreConsoleHost WithStartup<TStartup>(string[] args = default) where TStartup : BaseStartup, new()
        {
            var services= StartupUtil.GetServiceCollectionFrom<TStartup>(args);
            var registrar = new TypeRegistrar(services);
            var app = new CommandApp(registrar);
            return new SpectreConsoleHost(app);
        }

        public SpectreConsoleHost UseConfigurator<TConfigurator>() where TConfigurator : class, ISpectreConfiguration, new()
        {
            TConfigurator configurator = new TConfigurator();
            app.Configure(options => 
            {
                configurator.ConfigureCommandApp(in options);
            });
            return this;
        }

        public Task<int> RunAsync(string[] args)
        {
            return app.RunAsync(args);
        }
    }
}