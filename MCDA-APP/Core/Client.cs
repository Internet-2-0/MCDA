using MCDA_APP.Json;
using MCDA_APP.Model;
using MCDA_APP.Model.Agent;
using MCDA_APP.Model.Api;
using MCDA_APP.Web;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MCDA_APP.Core
{
    public class Client
    {
        private readonly CustomHttpClient _customHttpClient;
        
        public Client()
        {
            _customHttpClient = new CustomHttpClient();
        }

        public async Task<AccountInformation?> Login(string email, string password)
        {
            try
            {
                UserData userData = new() { Email = email, Password = password };

                string response = await _customHttpClient.SendJsonRequestAsync(
                    $"{Constants.ApiBaseUrl}/auth/login", HttpMethod.Post, userData);

                var settings = new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new AuthResponseConverter() },
                };

                AccountInformation? root = JsonConvert.DeserializeObject<AccountInformation>(response, settings);
                return root;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SendAgentStatus()
        {
            AgentStatus agentStatus = new()
            {
                Payload = new Payload{ Message = "Agent Started" },
                Type = "started"
            };

            _customHttpClient.AddHeader("apiKey", "");
            _customHttpClient.AddHeader("source", "agent");
            _customHttpClient.AddHeader("agentVersion", Helper.GetAgentVersion());

            try
            {
                await _customHttpClient.SendJsonRequestAsync($"{Constants.ApiBaseUrl}/agent/stat", HttpMethod.Post, agentStatus);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            _customHttpClient.RemoveHeader("apiKey");
            _customHttpClient.RemoveHeader("source");
            _customHttpClient.RemoveHeader("agentVersion");
        }
    }
}
