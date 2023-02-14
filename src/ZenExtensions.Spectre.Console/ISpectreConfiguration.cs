using Spectre.Console.Cli;

namespace ZenExtensions.Spectre.Console
{
    public interface ISpectreConfiguration
    {
        void ConfigureCommandApp(in IConfigurator configurator);
    }
}