using HistoryOfScienceAPI.Models;

namespace HistoryOfScienceAPI.Interfaces.Repositorys
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task AddAsync(Person person);
    }
}
