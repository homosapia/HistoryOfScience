using HistoryOfScienceAPI.Interfaces.Client;
using HistoryOfScienceAPI.Interfaces.Services;
using HistoryOfScienceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HistoryOfScienceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILMStudioClient _client;
        public PersonController(ILMStudioClient client, IPersonService personService) 
        {
            _client = client;
            _personService = personService;
        }

        [HttpGet]
        [Route("GetPersons")]
        public async Task<IActionResult> GetAllPerson() 
        {
            var list = await _personService.GetAllAsync();
            return Ok(list);
        }

        [HttpGet]
        [Route("StartDownloading")]
        public async Task<IActionResult> StartDownloading(string text)
        {
            LMStudioService studioService = new LMStudioService(_client);
            List<string> model = await studioService.GetListModel();

            string answer = await studioService.LocalRequest(model.First(), text);
            return Ok(answer);
        }
    }
}
