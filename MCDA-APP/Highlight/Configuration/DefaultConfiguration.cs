using System.Xml.Linq;

namespace MCDA_APP.Highlight.Configuration
{
    public class DefaultConfiguration : XmlConfiguration
    {
        public DefaultConfiguration()
        {
            XmlDocument = XDocument.Load("AssemblyDefinition.xml");
        }
    }
}
