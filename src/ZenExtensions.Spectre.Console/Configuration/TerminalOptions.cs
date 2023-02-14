using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace ZenExtensions.Spectre.Console.Configuration
{
    public class TerminalConfiguration
    {
        public Spinner Spinner { get; set; } = Spinner.Known.Monkey;
        public TableBorder TableBorder { get; set; } = TableBorder.Ascii;

        public static TerminalConfiguration Instance { get; } = new TerminalConfiguration();

        internal ProgressColumn[] ProgressColumns
        {
            get
            {
                var columns = new List<ProgressColumn>();
                columns.Add(new TaskDescriptionColumn());
                columns.Add(new ProgressBarColumn());
                columns.Add(new PercentageColumn());
                columns.Add(new SpinnerColumn(Spinner));
                return columns.ToArray();
            }
        }

        public static void Configure(Action<TerminalConfiguration> options)
        {
            options(Instance);
        }
    }
}