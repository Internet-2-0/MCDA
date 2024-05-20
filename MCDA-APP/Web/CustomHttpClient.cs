using MCDA_APP.Model.Agent;
using Newtonsoft.Json;
using System.Net;
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

        public async Task<string> PostRequestWithFilesAsync(string endpoint, List<FileToUpload> filesList)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                var content = new MultipartFormDataContent();

                for (int i = 0; i < filesList.Count; i++)
                    content.Add(new StreamContent(new MemoryStream(filesList[i].Binary!)), $"filename{i + 1}", filesList[i].FileName!);

                request.Content = content;

                var response = await _httpClient.SendAsync(request);

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> PostRequestWithFileAsyncMock(string endpoint, List<byte[]> files)
        {
            return "{\"data\":{\"data\":{\"group_by_10\":{\"results\":{\"kinda_similar\":[\"no code reuse discovered\"],\"very_similar\":[\"no code reuse discovered\"],\"perfect_similarity\":[[\"mov edx, 0x9b4000e\\nint 0x21\\nmov eax, 0x21cd4c01\\npush rsp\\npush 0x70207369\\njb 0xc5\\njb 0xba\\ninsd dword ptr [rdi], dx\\nand byte ptr [rbx + 0x61], ah\\noutsb dx, byte ptr [rsi]\",\"mov edx, 0x9b4000e\\nint 0x21\\nmov eax, 0x21cd4c01\\npush rsp\\npush 0x70207369\\njb 0xc5\\njb 0xba\\ninsd dword ptr [rdi], dx\\nand byte ptr [rbx + 0x61], ah\\noutsb dx, byte ptr [rsi]\",0],[\"outsb dx, byte ptr [rsi]\\nnop\\nje 0x82\\ndb 0x62\\nand byte ptr gs:[rdx + 0x75], dh\\noutsb dx, byte ptr [rsi]\\nand byte ptr [rcx + 0x6e], ch\\nand byte ptr [rdi + rcx*2 + 0x53], al\\nand byte ptr [rbp + 0x6f], ch\\nor eax, 0x240a0d\",\"outsb dx, byte ptr [rsi]\\nnop\\nje 0x82\\ndb 0x62\\nand byte ptr gs:[rdx + 0x75], dh\\noutsb dx, byte ptr [rsi]\\nand byte ptr [rcx + 0x6e], ch\\nand byte ptr [rdi + rcx*2 + 0x53], al\\nand byte ptr [rbp + 0x6f], ch\\nor eax, 0x240a0d\",0],[\"wait \\nstd \\nmov ebp, 0xbdfb9b95\\nxchg eax, esp\\nwait \\nsar dword ptr [rbp - 0x2910646b], cl\\nxchg eax, esp\\ndb 0x9a\\nmov ebp, 0xd6ef9b95\\nxchg eax, ecx\",\"wait \\nstd \\nmov ebp, 0xbdfb9b95\\nxchg eax, esp\\nwait \\nsar dword ptr [rbp - 0x2910646b], cl\\nxchg eax, esp\\ndb 0x9a\\nmov ebp, 0xd6ef9b95\\nxchg eax, ecx\",0]]}},\"group_by_5\":{\"results\":{\"kinda_similar\":[\"no code reuse discovered\"],\"very_similar\":[\"no code reuse discovered\"],\"perfect_similarity\":[[\"mov edx, 0x9b4000e\\nint 0x21\\nmov eax, 0x21cd4c01\\npush rsp\\npush 0x70207369\",\"mov edx, 0x9b4000e\\nint 0x21\\nmov eax, 0x21cd4c01\\npush rsp\\npush 0x70207369\",0],[\"jb 0xc5\\njb 0xba\\ninsd dword ptr [rdi], dx\\nand byte ptr [rbx + 0x61], ah\\noutsb dx, byte ptr [rsi]\",\"jb 0xc5\\njb 0xba\\ninsd dword ptr [rdi], dx\\nand byte ptr [rbx + 0x61], ah\\noutsb dx, byte ptr [rsi]\",0],[\"outsb dx, byte ptr [rsi]\\nnop\\nje 0x82\\ndb 0x62\\nand byte ptr gs:[rdx + 0x75], dh\",\"outsb dx, byte ptr [rsi]\\nnop\\nje 0x82\\ndb 0x62\\nand byte ptr gs:[rdx + 0x75], dh\",0]]}},\"group_by_15\":{\"results\":{\"kinda_similar\":[\"no code reuse discovered\"],\"very_similar\":[\"no code reuse discovered\"],\"perfect_similarity\":[[\"mov edx, 0x9b4000e\\nint 0x21\\nmov eax, 0x21cd4c01\\npush rsp\\npush 0x70207369\\njb 0xc5\\njb 0xba\\ninsd dword ptr [rdi], dx\\nand byte ptr [rbx + 0x61], ah\\noutsb dx, byte ptr [rsi]\\noutsb dx, byte ptr [rsi]\\nnop\\nje 0x82\\ndb 0x62\\nand byte ptr gs:[rdx + 0x75], dh\",\"mov edx, 0x9b4000e\\nint 0x21\\nmov eax, 0x21cd4c01\\npush rsp\\npush 0x70207369\\njb 0xc5\\njb 0xba\\ninsd dword ptr [rdi], dx\\nand byte ptr [rbx + 0x61], ah\\noutsb dx, byte ptr [rsi]\\noutsb dx, byte ptr [rsi]\\nnop\\nje 0x82\\ndb 0x62\\nand byte ptr gs:[rdx + 0x75], dh\",0],[\"wait \\nstd \\nmov ebp, 0xbdfb9b95\\nxchg eax, esp\\nwait \\nsar dword ptr [rbp - 0x2910646b], cl\\nxchg eax, esp\\ndb 0x9a\\nmov ebp, 0xd6ef9b95\\nxchg eax, ecx\\ndb 0x9a\\ndb 0xea\\nmov ebp, 0xd6ef9b95\\nxchg eax, esi\\ndb 0x9a\",\"wait \\nstd \\nmov ebp, 0xbdfb9b95\\nxchg eax, esp\\nwait \\nsar dword ptr [rbp - 0x2910646b], cl\\nxchg eax, esp\\ndb 0x9a\\nmov ebp, 0xd6ef9b95\\nxchg eax, ecx\\ndb 0x9a\\ndb 0xea\\nmov ebp, 0xd6ef9b95\\nxchg eax, esi\\ndb 0x9a\",0],[\"stc \\nmov ebp, 0xd6ef9b95\\npopfq \\ndb 0x9a\\nclc \\nmov ebp, 0xd6ef9b95\\nnop \\ndb 0x9a\\nstc \\nmov ebp, 0xd6ef9b95\\npush -0x65\\ncli \\nmov ebp, 0xd6ef9b95\\nxchg eax, edi\\ndb 0x9a\",\"stc \\nmov ebp, 0xd6ef9b95\\npopfq \\ndb 0x9a\\nclc \\nmov ebp, 0xd6ef9b95\\nnop \\ndb 0x9a\\nstc \\nmov ebp, 0xd6ef9b95\\npush -0x65\\ncli \\nmov ebp, 0xd6ef9b95\\nxchg eax, edi\\ndb 0x9a\",0]]}},\"scan_id\":\"662912371e0e232bcbe86d37\",\"scan_url\":\"https://app.malcore.io/report/662912371e0e232bcbe86d22/scan/undefined\",\"report_id\":\"662912371e0e232bcbe86d22\"},\"isMaintenance\":false,\"success\":true,\"messages\":[{\"type\":\"success\",\"code\":200,\"message\":\"Scan is running\"}]},\"isMaintenance\":false,\"success\":true}";
        }

        public async Task<(string, HttpStatusCode)> PostRequestWithFileAsync(string url, byte[] file, string fileName)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var content = new MultipartFormDataContent
                {
                    { new StreamContent(new MemoryStream(file)), $"filename1", fileName }
                };

                request.Content = content;

                var response = await _httpClient.SendAsync(request);
                
                string responseContent = await response.Content.ReadAsStringAsync();
                return (responseContent, response.StatusCode);
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

        public string SendJsonRequest(string url, object? requestBody)
        {
            if (requestBody is null)
            {
                return string.Empty;
            }

            string jsonBody = JsonConvert.SerializeObject(requestBody);
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync(url, content).Result;

            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }


        public async Task<string> SendJsonRequestAsync(string url, object? requestBody)
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

        public async Task<(string, HttpStatusCode)> PostAsync(string url, object? requestBody)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, requestBody);

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content.ReadAsStringAsync();
            return (responseString, response.StatusCode);
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

    }
}
