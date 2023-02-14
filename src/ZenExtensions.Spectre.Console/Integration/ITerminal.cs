using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ZenExtensions.Spectre.Console.Integration
{
    public interface IAnsiConsoleTerminal
    {
        T Ask<T>(string prompt);
        T Ask<T>(string prompt, T defaultValue);
        void Clear();
        bool Confirm(string prompt, bool defaultValue = true);
        LiveDisplay Live(IRenderable target);
        void Markup(IFormatProvider provider, string format, params object[] args);
        void Markup(string format, params object[] args);
        void Markup(string value);
        void MarkupLine(IFormatProvider provider, string format, params object[] args);
        void MarkupLine(string format, params object[] args);
        void MarkupLine(string value);
        T Prompt<T>(IPrompt<T> prompt);
        void Write(string format);
        void Write(IRenderable renderable);
        void Render(IRenderable renderable);
        void WriteLine(string format);
        void Write(string format, params object[] args);
        void WriteLine(string format, params object[] args);
        void WriteException(Exception exception, ExceptionFormats format = ExceptionFormats.Default);
        void WriteException(Exception exception, ExceptionSettings settings);
    }

    public interface IZenConsoleTerminal
    {

        Task<T> AskAsync<T>(string prompt, CancellationToken cancellationToken = default);
        Task<T> AskAsync<T>(string prompt, T defaultValue, CancellationToken cancellationToken = default);
        Task<bool> ConfirmAsync(string prompt, bool defaultValue = true, CancellationToken cancellationToken = default);
        Task<T> PromptAsync<T>(string message, CancellationToken cancellationToken = default);
        
        Task StatusAsync(string message, Func<StatusContext, Task> func);
        Task<T> StatusAsync<T>(string message, Func<StatusContext, Task<T>> func);
        void WriteBulletPoint(string text);
        void WriteError(string message);
        void WriteSuccess(string message);
        void WriteWarning(string message);
        void WriteInfo(string message);
        Table Table(string title, Justify justify = Justify.Left);
        Table Table(string title, IEnumerable<string> columns, Justify justify = Justify.Left);
        Progress CreateProgress();
        Task CreateProgressTaskAsync(string description, double maxCount, Func<ProgressTask, Task> func);
        Task<T> CreateProgressTaskAsync<T>(string description, double maxCount, Func<ProgressTask, Task<T>> func) where T : notnull;
        Task<List<T>> MultiSelectionPromptAsync<T>(string prompt, IEnumerable<T> choices, CancellationToken cancellationToken = default) where T : notnull;
        Task<T> SingleSelectionPromptAsync<T>(string prompt, IEnumerable<T> choices, CancellationToken cancellationToken = default) where T : notnull;
    }
    public interface ITerminal : IZenConsoleTerminal, IAnsiConsoleTerminal
    {
        
    }
}