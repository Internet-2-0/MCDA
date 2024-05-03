using Newtonsoft.Json;

namespace MCDA_APP.Model.Agent.Disassembler
{
    public class RadareImport
    {
        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty("bind")]
        public string? Bind { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("libname")]
        public string? Libname { get; set; }

        [JsonProperty("plt")]
        public long Plt { get; set; }
    }
}
