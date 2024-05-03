using MCDA_APP.Highlight.Patterns;

namespace MCDA_APP.Highlight.Engines
{
    public interface IEngine
    {
        string Highlight(Definition definition, string input);
    }
}
