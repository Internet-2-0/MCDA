using MCDA_APP.Json;
using MCDA_APP.Model;
using MCDA_APP.Model.Agent;
using MCDA_APP.Model.Api;
using MCDA_APP.Web;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace MCDA_APP.Core
{
    public class Client
    {
        private readonly CustomHttpClient _customHttpClient;
        
        public Client()
        {
            _customHttpClient = new CustomHttpClient();

            _customHttpClient.AddHeader("source", "agent");
            _customHttpClient.AddHeader("agentVersion", Helper.GetAgentVersion());
        }

        public void AddApiKey(string apiKey)
        {
            _customHttpClient.AddHeader("apiKey", apiKey);
        }

        public async Task<AccountInformation?> Login(string email, string password)
        {
            try
            {
                UserData userData = new() { Email = email, Password = password };

                string response = await _customHttpClient.SendJsonRequestAsync(
                    $"{Constants.ApiBaseUrl}/auth/login", userData);

                var settings = new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new AuthResponseConverter() },
                };

                AccountInformation? root = JsonConvert.DeserializeObject<AccountInformation>(response, settings);

                _customHttpClient.AddHeader("apiKey", root?.ApiKey!);

                return root;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<string> UploadFiles(string endpoint, List<FileToUpload> filesList)
        {
            try
            {
                string response = await _customHttpClient.PostRequestWithFilesAsync(endpoint, filesList);
                return response;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<(string, HttpStatusCode)> GetUsage()
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;
            try
            {
                var requestContent = new StringContent("", Encoding.Unicode, "application/json");
                var response = await _customHttpClient.PostAsync($"{Constants.ApiBaseUrl}/agent/usage", requestContent);
                statusCode = response.Item2;

                return (response.Item1, statusCode);
            }catch(Exception)
            {
                return ("", statusCode);
            }
        }

        public void SendAgentStatus(string type = "", string pName = "", string pType = "", string pMessage = "", string pResponse = "")
        {
            try
            {
                AgentStatus agentStatus = new AgentStatus
                {
                    Type = type,
                    Payload = new Payload
                    {
                        Name = pName,
                        Type = pType,
                        Response = pResponse,
                        Message = pMessage
                    }
                };
                _customHttpClient.SendJsonRequest($"{Constants.ApiBaseUrl}/agent/stat", agentStatus);
            }
            catch (Exception)
            {
            }
        }

        public async Task<(string, HttpStatusCode)> UploadFile(string url, byte[] file, string fileName) 
        {
            try
            {
                var response = await _customHttpClient.PostRequestWithFileAsync(url, file, fileName);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SendAgentStatusAsync(AgentStatus agentStatus)
        {
            //AgentStatus agentStatus = new()
            //{
            //    Payload = new Payload{ Message = "Agent Started" },
            //    Type = "started"
            //};

            try
            {
                await _customHttpClient.SendJsonRequestAsync($"{Constants.ApiBaseUrl}/agent/stat", agentStatus);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
