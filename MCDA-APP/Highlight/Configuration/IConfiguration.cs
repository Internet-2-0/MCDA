using MCDA_APP.Highlight.Patterns;

namespace MCDA_APP.Highlight.Configuration
{
    public interface IConfiguration
    {
        IDictionary<string, Definition> Definitions { get; }
    }
}
