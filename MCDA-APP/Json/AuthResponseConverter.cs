using MCDA_APP.Model.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MCDA_APP.Json
{
    public class AuthResponseConverter : JsonConverter<AccountInformation>
    {
        public override AccountInformation? ReadJson(JsonReader reader, Type objectType, AccountInformation? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            AccountInformation response = new();

            var token = JToken.Load(reader);

            //if (token["success"] == null)
            //    return response;

            if ((bool)token["success"]! != true)
            {
                response.Message = (string?)token["data"]?["messages"]?[0]?["message"];
                return response;
            }

            response.Success = (bool)token["success"]!;
            response.ApiKey = (string?)token["data"]?["user"]?["apiKey"];
            response.UserEmail = (string?)token["data"]?["user"]?["email"];
            response.Subscription = (string?)token["data"]?["user"]?["subscription"]?["name"];
            response.Message = (string?)token["data"]?["messages"]?[0]?["message"];
            
            return response;
        }

        public override void WriteJson(JsonWriter writer, AccountInformation? value, JsonSerializer serializer)
        {
            
        }
    }
}
