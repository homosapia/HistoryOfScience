using HistoryOfScienceAPI.LMStudio.Model;

namespace HistoryOfScienceAPI.Interfaces.Client
{
    public interface ILMStudioClient
    {
        public Task<List<LMModel>> GetModels();
        public Task<string> SendMessageAsync(string model, string userMessage, string systemMessage);
    }
}
