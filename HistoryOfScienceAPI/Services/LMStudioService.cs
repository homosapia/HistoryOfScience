using HistoryOfScienceAPI.Interfaces.Client;

namespace HistoryOfScienceAPI.Services
{
    public class LMStudioService
    {
        private readonly ILMStudioClient _client;
        public LMStudioService(ILMStudioClient client) 
        {
            _client = client;
        }

        public async Task<List<string>> GetListModel()
        {
            var models = await _client.GetModels();
            return models.Select(x => x.id).ToList();
        }

        public async Task<string> LocalRequest(string model, string message)
        {
            return await _client.SendMessageAsync(model, message, "Ты AI-ассистент помоги ползователю с его вопросом");
        }
    }
}
