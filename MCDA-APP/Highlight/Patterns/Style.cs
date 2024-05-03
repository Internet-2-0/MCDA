namespace MCDA_APP.Highlight.Patterns
{
    public class Style
    {
        public ColorPair Colors { get; private set; }
        public SixLabors.Fonts.Font Font { get; private set; }

        public Style(ColorPair colors, SixLabors.Fonts.Font font)
        {
            Colors = colors;
            Font = font;
        }
    }
}