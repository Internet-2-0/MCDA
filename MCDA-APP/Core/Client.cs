using MCDA_APP.Json;
using MCDA_APP.Model;
using MCDA_APP.Model.Agent;
using MCDA_APP.Model.Api;
using MCDA_APP.Web;
using Newtonsoft.Json;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MCDA_APP.Core
{
    public class Client
    {
        private readonly CustomHttpClient _customHttpClient;
        
        public Client()
        {
            _customHttpClient = new CustomHttpClient();
            SetupHeaders();
        }

        private void SetupHeaders()
        {
            _customHttpClient.AddHeader("apiKey", "");
            _customHttpClient.AddHeader("source", "agent");
            _customHttpClient.AddHeader("agentVersion", Helper.GetAgentVersion());
        }

        public async Task Login(string email, string password)
        {
            try
            {
                string response = await _customHttpClient.SendJsonRequestAsync($"{Constants.ApiBaseUrl}/auth/login", HttpMethod.Post, 
                    new UserData() { Email = email, Password = password });

                var settings = new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new AuthResponseConverter() },
                };

                AccountInformation? root = JsonConvert.DeserializeObject<AccountInformation>(response, settings);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task SendAgentStatus()
        {
            AgentStatus agentStatus = new()
            {
                Payload = new Payload{ Message = "Agent Started" },
                Type = "started"
            };

            try
            {
                await _customHttpClient.SendJsonRequestAsync($"{Constants.ApiBaseUrl}/agent/stat", HttpMethod.Post, agentStatus);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
