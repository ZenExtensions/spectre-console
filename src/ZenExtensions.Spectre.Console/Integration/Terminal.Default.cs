using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ZenExtensions.Spectre.Console.Integration
{
    public partial class Terminal : IAnsiConsoleTerminal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Ask<T>(string prompt)
        {
            return AnsiConsole.Ask<T>(prompt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Ask<T>(string prompt, T defaultValue)
        {
            return AnsiConsole.Ask<T>(prompt, defaultValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            AnsiConsole.Clear();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Confirm(string prompt, bool defaultValue = true)
        {
            return AnsiConsole.Confirm(prompt, defaultValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LiveDisplay Live(IRenderable target)
        {
            return AnsiConsole.Live(target);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Markup(IFormatProvider provider, string format, params object[] args)
        {
            AnsiConsole.Markup(provider, format, args);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Markup(string format, params object[] args)
        {
            AnsiConsole.Markup(format, args);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Markup(string value)
        {
            AnsiConsole.Markup(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MarkupLine(IFormatProvider provider, string format, params object[] args)
        {
            AnsiConsole.MarkupLine(provider, format, args);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MarkupLine(string format, params object[] args)
        {
            AnsiConsole.MarkupLine(format, args);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MarkupLine(string value)
        {
            AnsiConsole.MarkupLine(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Prompt<T>(IPrompt<T> prompt)
        {
            return AnsiConsole.Prompt<T>(prompt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Render(IRenderable renderable)
        {
            AnsiConsole.Write(renderable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(string format)
        {
            AnsiConsole.Write(format);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(string format, params object[] args)
        {
            AnsiConsole.Write(format, args);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(IRenderable renderable)
        {
            AnsiConsole.Write(renderable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteException(Exception exception, ExceptionFormats format = ExceptionFormats.Default)
        {
            AnsiConsole.WriteException(exception, format);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteException(Exception exception, ExceptionSettings settings)
        {
            AnsiConsole.WriteException(exception, settings);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteLine(string format)
        {
            AnsiConsole.WriteLine(format);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteLine(string format, params object[] args)
        {
            AnsiConsole.WriteLine(format, args);
        }
    }
}