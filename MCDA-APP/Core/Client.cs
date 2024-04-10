using MCDA_APP.Model.Agent;
using MCDA_APP.Web;
using System.Diagnostics;

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
            if (_customHttpClient is null)
            {
                return;
            }

            _customHttpClient.AddHeader("apiKey", "");
            _customHttpClient.AddHeader("source", "agent");
            _customHttpClient.AddHeader("agentVersion", Helper.GetAgentVersion());
        }

        public async Task SendAgentStatus()
        {
            if (_customHttpClient is null)
            {
                return;
            }

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
