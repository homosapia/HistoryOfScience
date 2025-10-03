using HistoryOfScienceAPI.Interfaces.Repositorys;
using HistoryOfScienceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HistoryOfScienceAPI.DataBase.Repositorys
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return _context.Persons.Single(x => x.Id == id);
        }
    }
}
