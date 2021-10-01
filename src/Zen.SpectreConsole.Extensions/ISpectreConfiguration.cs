using Spectre.Console.Cli;

namespace Zen.SpectreConsole.Extensions
{
    public interface ISpectreConfiguration
    {
        void ConfigureCommandApp(in IConfigurator configurator);
    }
}