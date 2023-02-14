using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using ZenExtensions.Spectre.Console.Configuration;

namespace ZenExtensions.Spectre.Console.Integration
{
    public partial class Terminal : IZenConsoleTerminal
    {
        public Task<T> AskAsync<T>(string prompt, T defaultValue, CancellationToken cancellationToken = default)
        {
            return new TextPrompt<T>(prompt)
                .DefaultValue(defaultValue)
                .ShowAsync(AnsiConsole.Console, cancellationToken);
        }

        public Task<T> AskAsync<T>(string prompt, CancellationToken cancellationToken = default)
        {
            return new TextPrompt<T>(prompt)
                .ShowAsync(AnsiConsole.Console, cancellationToken);
        }

        public Task<bool> ConfirmAsync(string prompt, bool defaultValue = true, CancellationToken cancellationToken = default)
        {
            return new ConfirmationPrompt(prompt)
            {
                DefaultValue = defaultValue
            }.ShowAsync(AnsiConsole.Console, cancellationToken);
        }

        public Progress CreateProgress()
        {
            return AnsiConsole.Progress()
                .Columns(TerminalConfiguration.Instance.ProgressColumns);
        }

        public Task CreateProgressTaskAsync(string description, double maxCount, Func<ProgressTask, Task> func)
        {
            return CreateProgress()
                .StartAsync(context =>
                {
                    var progressTask = context.AddTask(description, maxValue: maxCount);
                    return func(progressTask);
                });
        }

        public Task<T> CreateProgressTaskAsync<T>(string description, double maxCount, Func<ProgressTask, Task<T>> func) where T : notnull
        {
            return CreateProgress()
                .StartAsync<T>(context =>
                {
                    var progressTask = context.AddTask(description, maxValue: maxCount);
                    return func(progressTask);
                });
        }

        public Task<List<T>> MultiSelectionPromptAsync<T>(string prompt, IEnumerable<T> choices, CancellationToken cancellationToken = default) where T : notnull
        {
            return new MultiSelectionPrompt<T>()
                .Title(prompt)
                .Required()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle a type, " + 
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(choices)
                .ShowAsync(AnsiConsole.Console, cancellationToken);
        }

        public Table Table(string title, Justify justify = Justify.Left)
        {
            return new Table()
                .Title(title)
                .Alignment(justify)
                .Border(TerminalConfiguration.Instance.TableBorder);
        }

        public Table Table(string title, IEnumerable<string> columns, Justify justify = Justify.Left)
        {
            return Table(title, justify)
                .AddColumns(
                    columns.Select(header => new TableColumn(header).Alignment(justify)).ToArray()
                );
        }

        public Task<T> PromptAsync<T>(string message, CancellationToken cancellationToken = default)
        {
            return new TextPrompt<T>(message)
                .ShowAsync(AnsiConsole.Console, cancellationToken);
        }

        public Task<T> SingleSelectionPromptAsync<T>(string prompt, IEnumerable<T> choices, CancellationToken cancellationToken = default) where T : notnull
        {
            return new SelectionPrompt<T>()
                .Title(prompt)
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
                .AddChoices(choices)
                .ShowAsync(AnsiConsole.Console, cancellationToken);
        }

        public Task StatusAsync(string message, Func<StatusContext, Task> func)
        {
            return AnsiConsole.Status()
                .Spinner(TerminalConfiguration.Instance.Spinner)
                .StartAsync(message, func);
        }

        public Task<T> StatusAsync<T>(string message, Func<StatusContext, Task<T>> func)
        {
            return AnsiConsole.Status()
                .Spinner(TerminalConfiguration.Instance.Spinner)
                .StartAsync<T>(message, func);
        }

        public void WriteBulletPoint(string text)
        {
            AnsiConsole.MarkupLine($":backhand_index_pointing_right: {text}");
        }

        public void WriteError(string message)
        {
            AnsiConsole.MarkupLine($":cross_mark: [red]{message}[/]");
        }

        public void WriteInfo(string message)
        {
            AnsiConsole.MarkupLine($":check_mark: [grey69]{message}[/]");
        }

        public void WriteSuccess(string message)
        {
            AnsiConsole.MarkupLine($":check_mark_button: [green]{message}[/]");
        }

        public void WriteWarning(string message)
        {
            AnsiConsole.MarkupLine($":warning: [yellow]{message}[/]");
        }
    }
}