using Newtonsoft.Json;

namespace MCDA_APP.Model.Agent.Disassembler
{
    public class RadareString
    {
        [JsonProperty("vaddr")]
        public long Vaddr { get; set; }

        [JsonProperty("paddr")]
        public int Paddr { get; set; }

        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("section")]
        public string? Section { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("string")]
        public string? String { get; set; }
    }
}
