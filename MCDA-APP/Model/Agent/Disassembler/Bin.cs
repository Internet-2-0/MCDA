using Newtonsoft.Json;

namespace MCDA_APP.Model.Agent.Disassembler
{
    public class Bin
    {
        [JsonProperty("arch")]
        public string? Arch { get; set; }

        [JsonProperty("baddr")]
        public long Baddr { get; set; }

        [JsonProperty("binsz")]
        public int Binsz { get; set; }

        [JsonProperty("bintype")]
        public string? Bintype { get; set; }

        [JsonProperty("bits")]
        public int Bits { get; set; }

        [JsonProperty("canary")]
        public bool Canary { get; set; }

        [JsonProperty("retguard")]
        public bool Retguard { get; set; }

        [JsonProperty("class")]
        public string? Class { get; set; }

        [JsonProperty("cmp.csum")]
        public string? CmpCsum { get; set; }

        [JsonProperty("compiled")]
        public string? Compiled { get; set; }

        [JsonProperty("compiler")]
        public string? Compiler { get; set; }

        [JsonProperty("crypto")]
        public bool Crypto { get; set; }

        [JsonProperty("dbg_file")]
        public string? DbgFile { get; set; }

        [JsonProperty("endian")]
        public string? Endian { get; set; }

        [JsonProperty("havecode")]
        public bool Havecode { get; set; }

        [JsonProperty("hdr.csum")]
        public string? HdrCsum { get; set; }

        [JsonProperty("guid")]
        public string? Guid { get; set; }

        [JsonProperty("intrp")]
        public string? Intrp { get; set; }

        [JsonProperty("laddr")]
        public int Laddr { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("linenum")]
        public bool Linenum { get; set; }

        [JsonProperty("lsyms")]
        public bool Lsyms { get; set; }

        [JsonProperty("machine")]
        public string? Machine { get; set; }

        [JsonProperty("nx")]
        public bool Nx { get; set; }

        [JsonProperty("os")]
        public string? Os { get; set; }

        [JsonProperty("overlay")]
        public bool Overlay { get; set; }

        [JsonProperty("cc")]
        public string? Cc { get; set; }

        [JsonProperty("pic")]
        public bool Pic { get; set; }

        [JsonProperty("relocs")]
        public bool Relocs { get; set; }

        [JsonProperty("rpath")]
        public string? Rpath { get; set; }

        [JsonProperty("signed")]
        public bool Signed { get; set; }

        [JsonProperty("sanitize")]
        public bool Sanitize { get; set; }

        [JsonProperty("static")]
        public bool Static { get; set; }

        [JsonProperty("stripped")]
        public bool Stripped { get; set; }

        [JsonProperty("subsys")]
        public string? Subsys { get; set; }

        [JsonProperty("va")]
        public bool Va { get; set; }

        [JsonProperty("checksums")]
        public object? Checksums { get; set; }
    }
}