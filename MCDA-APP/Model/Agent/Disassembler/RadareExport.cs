using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDA_APP.Model.Agent.Disassembler
{
    public class RadareExport
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("flagname")]
        public string? Flagname { get; set; }

        [JsonProperty("realname")]
        public string? Realname { get; set; }

        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty("bind")]
        public string? Bind { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("vaddr")]
        public long Vaddr { get; set; }

        [JsonProperty("paddr")]
        public int Paddr { get; set; }

        [JsonProperty("is_imported")]
        public bool IsImported { get; set; }
    }
}
