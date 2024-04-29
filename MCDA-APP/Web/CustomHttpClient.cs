using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace MCDA_APP.Web
{
    public class CustomHttpClient
    {
        private readonly HttpClient _httpClient;

        public CustomHttpClient()
        {
            _httpClient = new HttpClient();

            AddHeader("source", "agent");
            AddHeader("agentVersion", Helper.GetAgentVersion());
        }

        public void AddHeader(string key, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(key, value);
        }

        public void RemoveHeader(string key)
        {
            bool exists = _httpClient.DefaultRequestHeaders.Contains(key);

            if (exists)
            {
                _httpClient.DefaultRequestHeaders.Remove(key);
            }
        }

        public void ChangeHeader(string key, string newValue)
        {
            bool exists = _httpClient.DefaultRequestHeaders.Contains(key);

            if (exists)
            {
                _httpClient.DefaultRequestHeaders.Remove(key);
                _httpClient.DefaultRequestHeaders.Add(key, newValue);
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Add(key, newValue);
            }
        }

        public async Task<T> SendJsonRequestAsync<T>(string url, HttpMethod method, object requestBody)
        {
            var request = new HttpRequestMessage(method, url);

            if (requestBody is not null)
            {
                string jsonBody = JsonConvert.SerializeObject(requestBody);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseContent)!;
        }

        public async Task<string> SendJsonRequestAsync(string url, HttpMethod method, object? requestBody)
        {
            if (requestBody is null)
            {
                return string.Empty;
            }

            string jsonBody = JsonConvert.SerializeObject(requestBody);
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string url, object? requestBody)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, requestBody);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAsync(string url)
        {
           // _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

    }
}
