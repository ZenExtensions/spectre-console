using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console.Cli;
using ZenExtensions.Spectre.Console.Integration;

namespace ZenExtensions.Spectre.Console
{
    public abstract class ZenCommand<TSettings> : Command<TSettings>, IZenCommand
        where TSettings: ZenCommandSettings
    {
        protected TSettings Settings { get; private set; } = default!;
        protected ITerminal Terminal { get; private set; } = default!;

        public override int Execute([NotNull] CommandContext context, [NotNull] TSettings settings)
        {
            Terminal = new Terminal();
            var cancellationTokenSource = new CancellationTokenSource();
            System.Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs args)
            {
                cancellationTokenSource.Cancel();
                args.Cancel = true;
            }!;
            OnExecute(context, cancellationTokenSource.Token);
            return 0;
        }

        public abstract void OnExecute(CommandContext context, CancellationToken cancellationToken);
    }
}