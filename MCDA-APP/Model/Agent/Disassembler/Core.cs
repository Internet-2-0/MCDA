using Newtonsoft.Json;

namespace MCDA_APP.Model.Agent.Disassembler
{
    public class Core
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("file")]
        public string? File { get; set; }

        [JsonProperty("fd")]
        public int Fd { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("humansz")]
        public string? Humansz { get; set; }

        [JsonProperty("iorw")]
        public bool Iorw { get; set; }

        [JsonProperty("mode")]
        public string? Mode { get; set; }

        [JsonProperty("block")]
        public int Block { get; set; }

        [JsonProperty("format")]
        public string? Format { get; set; }
    }
}
