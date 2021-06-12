using System.Threading.Tasks;
using Spectre.Console.Cli;
using Zen.SpectreConsole.Extensions.Infrastructure;

namespace Zen.SpectreConsole.Extensions
{
    public class SpectreConsoleHost
    {
        private readonly CommandApp app;
        public SpectreConsoleHost(CommandApp app)
        {
            this.app = app;
        }
        public static SpectreConsoleHost WithStartup<TStartup>() where TStartup : BaseStartup, new()
        {
            TStartup startup = new TStartup();
            var services = startup.Configure();
            var registrar = new TypeRegistrar(services);
            var app = new CommandApp(registrar);
            app.Configure(options => 
            {
                startup.ConfigureCommandApp(in options);
            });
            return new SpectreConsoleHost(app);
        }

        public Task<int> RunAsync(string[] args)
        {
            return app.RunAsync(args);
        }
    }
}