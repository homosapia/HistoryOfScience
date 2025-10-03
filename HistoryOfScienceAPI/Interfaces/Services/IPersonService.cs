using HistoryOfScienceAPI.Models;

namespace HistoryOfScienceAPI.Interfaces.Services
{
    public interface IPersonService
    {
        public Task<IEnumerable<Person>> GetAllAsync();

        public Task AddPersonAsync(Person person);
    }
}
