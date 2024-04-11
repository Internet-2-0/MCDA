using MCDA_APP.Model.Api;
using Newtonsoft.Json;

namespace MCDA_APP.Json
{
    public class AuthResponseConverter : JsonConverter<AccountInformation>
    {
        public override AccountInformation? ReadJson(JsonReader reader, Type objectType, AccountInformation? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, AccountInformation? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
