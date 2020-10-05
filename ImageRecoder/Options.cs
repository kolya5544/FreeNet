using CommandLine;

namespace ImageRecoder
{
    public enum ProcessingType
    {
        One = 1,
        Two = 2
    }

    public enum Meta
    {
        NoPostProcessing,
        OneFifth,
        OneTenth,
        OneTwentieth,
        OneFortieth,
        OneEightieth,
        BlackWhite,
        RandomResize
    }

    public class Options
    {
        [Value(0, MetaName = "input", Required = true, HelpText = "Input file path.")]
        public string Input { get; set; }

        [Value(1, MetaName = "output", Required = true, HelpText = "Output file path.")]
        public string Output { get; set; }

        [Option(shortName: 't', longName: "type", Required = true, HelpText = @"
1 - Takes the picture and saves it, removing most of metadata or byte hidden contents.
2 - Takes the picture and saves it to raw BMP HEX, removing all the sensitive information stored in a file.")]
        public ProcessingType Type { get; set; }

        [Option(shortName: 'm', longName: "meta", Required = false, Default = Meta.NoPostProcessing, HelpText = @"
[0] - No post-processing
1 - 1/5 colour equalization to remove a bit of hidden contents.
2 - 1/10 colour equalization to remove some of hidden contents.
3 - 1/20 colour equalization to remove most of hidden contents.
4 - 1/40 colour equalization to remove hidden contents at the cost of bad quality.
5 - 1/80 colour equalization. You can't be serious. Hope they dont find you.
6 - Colour to black/white.
7 - Resizes the picture by random amount of pixels to hide camera/phone model used to take the picture. (Best for pictures bigger than 100x100)")]
        public Meta Meta { get; set; }
    }
}
