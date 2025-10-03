using HistoryOfScienceAPI.Interfaces.Repositorys;
using HistoryOfScienceAPI.Interfaces.Services;
using HistoryOfScienceAPI.Models;

namespace HistoryOfScienceAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddPersonAsync(Person person)
        {
            await _repository.AddAsync(person);
        }
    }
}
