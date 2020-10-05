using CommandLine;
using CommandLine.Text;
using System;

namespace ImageRecoder
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var parser = new Parser(with => with.HelpWriter = null);
            var result = parser.ParseArguments<Options>(args);

            result
                .WithParsed(Processor.Run)
                .WithNotParsed(_ => DisplayHelp(result));
        }

        private static void DisplayHelp(ParserResult<Options> result)
        {
            var helpText = HelpText.AutoBuild(result, helpText =>
            {
                helpText.Heading = string.Empty;
                helpText.Copyright = string.Empty;
                helpText.AddPreOptionsLine("Usage: program.exe <input> <output> <type> [meta]");
                helpText.AddPostOptionsLine("Program source code: https://github.com/kolya5544/FreeNet/tree/master/ImageRecoder");
                return HelpText.DefaultParsingErrorsHandler(result, helpText);
            }, e => e);

            Console.WriteLine(helpText);
        }
    }
}
