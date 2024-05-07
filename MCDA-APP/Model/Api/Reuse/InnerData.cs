using Newtonsoft.Json;

namespace MCDA_APP.Model.Api.Reuse
{
    public class InnerData
    {
        [JsonProperty("group_by_10")]
        public DataGroup? DataBy10 { get; set; }

        [JsonProperty("group_by_5")]
        public DataGroup? DataBy5 { get; set; }

        [JsonProperty("group_by_15")]
        public DataGroup? DataBy15 { get; set; }

        [JsonProperty("scan_id")]
        public string? ScanId { get; set; }

        [JsonProperty("scan_url")]
        public string? ScanUrl { get; set; }

        [JsonProperty("report_id")]
        public string? ReportId { get; set; }
    }
}
