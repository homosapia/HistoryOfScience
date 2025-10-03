using HistoryOfScienceAPI.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HistoryOfScienceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService) 
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("GetPersons")]
        public async Task<IActionResult> GetAllPerson() 
        {
            var list = await _personService.GetAllAsync();
            return Ok(list);
        }
    }
}
