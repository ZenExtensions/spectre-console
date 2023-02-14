using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace ZenExtensions.Spectre.Console.Integration.Spinners
{
    public class EmptySpinner : Spinner
    {
        public override TimeSpan Interval => TimeSpan.MaxValue;

        public override bool IsUnicode => true;

        public override IReadOnlyList<string> Frames => new List<string>
        {
            ""
        };
    }
}