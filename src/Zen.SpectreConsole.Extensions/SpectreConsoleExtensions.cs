using Spectre.Console.Cli;
using Zen.SpectreConsole.Extensions.Infrastructure;

namespace Zen.SpectreConsole.Extensions
{
    public static class SpectreConsoleExtensions
    {
        public static ICommandConfigurator WithExample(this ICommandConfigurator builder, params string[] args)
        {
            return builder.WithExample(args);
        }

        public static ICommandConfigurator WithAliases(this ICommandConfigurator builder, params string[] args)
        {
            foreach (var argument in args)
            {
                builder.WithAlias(argument);
            }
            return builder;
        }
    }
}