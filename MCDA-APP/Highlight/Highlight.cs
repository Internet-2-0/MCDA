namespace MCDA_APP.Highlight
{
    public class Highlight
    {
        public int Start { get; }
        public int Length { get; }
        public string? Color { get; }

        public Highlight(int start, int length, string? color)
        {
            Start = start;
            Length = length;
            Color = color;
        }
    }
}
