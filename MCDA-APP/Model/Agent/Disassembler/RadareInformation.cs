using Newtonsoft.Json;

namespace MCDA_APP.Model.Agent.Disassembler
{
    public class RadareInformation
    {
        [JsonProperty("core")]
        public Core? Core { get; set; }

        [JsonProperty("bin")]
        public Bin? Bin { get; set; }
    }
}
