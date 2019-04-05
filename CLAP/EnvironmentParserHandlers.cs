using System.Diagnostics;

namespace CLAP
{
    internal static class EnvironmentParserHandlers
    {
        internal static MultiParser Console(this MultiParser parser)
        {
            parser.Register.HelpHandler("help,h,?", help => System.Console.WriteLine(help));
            parser.Register.ParameterHandler("debug", () => Debugger.Launch());
            parser.Register.ErrorHandler(c => System.Console.Error.WriteLine(c.Exception.Message));

            // a multi parser needs an empty help handler
            //
            if (parser.Types.Length > 1)
            {
                parser.Register.EmptyHelpHandler(help => System.Console.WriteLine(help));
            }

            return parser;
        }

        internal static MultiParser WinForms(this MultiParser parser)
        {
            parser.Register.HelpHandler("help,h,?", help => System.Console.WriteLine(help));
            parser.Register.ParameterHandler("debug", () => Debugger.Launch());
            parser.Register.ErrorHandler(c => System.Console.Error.WriteLine(c.Exception.Message));

            return parser;
        }
    }
}