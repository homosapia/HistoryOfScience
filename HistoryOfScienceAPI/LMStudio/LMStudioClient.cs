using HistoryOfScienceAPI.Interfaces.Client;
using HistoryOfScienceAPI.LMStudio.Model;
using System.Text;
using System.Text.Json;

namespace HistoryOfScienceAPI.LMStudio
{
    public class LMStudioClient : ILMStudioClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public LMStudioClient(string baseUrl = "http://localhost:1234")
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<List<LMModel>> GetModels()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/v1/models");
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<LMModelList>(responseJson, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return responseObject?.data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка: {ex.Message}", ex);
            }
        }

        public async Task<string> SendMessageAsync(string model, string userMessage, string systemMessage)
        {
            try
            {
                var requestData = new
                {
                    model = model,
                    messages = new[]
                    {
                        new { role = "system", content = systemMessage },
                        new { role = "user", content = userMessage }
                    },
                    temperature = 0.7,
                    max_tokens = -1,
                    stream = false
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/v1/chat/completions", content);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<LMStudioResponse>(responseJson, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return responseObject?.Choices?[0]?.Message?.Content ?? "Не удалось получить ответ";
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }
    }

    // Классы для десериализации ответа
    public class LMStudioResponse
    {
        public Choice[] Choices { get; set; }
    }

    public class Choice
    {
        public Message Message { get; set; }
    }

    public class Message
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }
}
