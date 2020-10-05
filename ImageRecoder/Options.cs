using CommandLine;

namespace ImageRecoder
{
    public enum ProcessingType
    {
        One,
        Two
    }

    public enum Meta
    {
        NoPostProcessing,
        OneFifth,
        OneTenth,
        OneTwentieth,
        OneFortieth,
        OneEightieth
    }

    public class Options
    {
        [Value(0, MetaName = "input", Required = true, HelpText = "Input file path.")]
        public string Input { get; set; }

        [Value(1, MetaName = "output", Required = true, HelpText = "Output file path.")]
        public string Output { get; set; }

        [Value(2, MetaName = "type", Required = true, HelpText = @"
1 - Takes the picture and saves it, removing most of metadata or byte hidden contents.
2 - Takes the picture and saves it to raw BMP HEX, removing all the sensitive information stored in a file.")]
        public ProcessingType Type { get; set; }

        [Value(3, MetaName = "meta", Required = false, Default = Meta.NoPostProcessing, HelpText = @"
[0] - No post-processing
1 - 1/5 colour equalization to remove a bit of hidden contents.
2 - 1/10 colour equalization to remove some of hidden contents.
3 - 1/20 colour equalization to remove most of hidden contents.
4 - 1/40 colour equalization to remove hidden contents at the cost of bad quality.
5 - 1/80 colour equalization. You can't be serious. Hope they dont find you.")]
        public Meta Meta { get; set; }
    }
}
