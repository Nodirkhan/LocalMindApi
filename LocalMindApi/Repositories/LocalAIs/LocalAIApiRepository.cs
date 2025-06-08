using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LocalMindApi.Models.LocalAIs;

namespace LocalMindApi.Repositories.LocalAIs
{
    public class LocalAIApiRepository : ILocalAIApiRepository
    {
        public async ValueTask<LocalAIResponse> PostLocalAIRequestAsync(LocalAIRequest localAIRequest)
        {
            using var httpClient = new HttpClient();
            string jsonBody = JsonSerializer.Serialize(localAIRequest);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:11434/api/generate", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<LocalAIResponse>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
