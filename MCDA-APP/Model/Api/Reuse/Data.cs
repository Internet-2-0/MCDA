using Newtonsoft.Json;

namespace MCDA_APP.Model.Api.Reuse
{
    public class Data
    {
        [JsonProperty("data")]
        public InnerData? InnerData { get; set; }
    }
}