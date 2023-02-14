using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console.Cli;
using ZenExtensions.Spectre.Console.Integration;

namespace ZenExtensions.Spectre.Console
{
    public abstract class ZenAsyncCommand<TSettings> : AsyncCommand<TSettings>, IZenCommand
        where TSettings: CommandSettings
    {
        protected TSettings Settings { get; private set; } = default!;
        protected ITerminal Terminal { get; private set; } = default!;

        public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TSettings settings)
        {
            Terminal = new Terminal();
            var cancellationTokenSource = new CancellationTokenSource();
            System.Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs args)
            {
                cancellationTokenSource.Cancel();
                args.Cancel = true;
            }!;
            await OnExecuteAsync(context, cancellationTokenSource.Token);
            return 1;
        }

        public abstract Task OnExecuteAsync(CommandContext context, CancellationToken cancellationToken);
    }
}