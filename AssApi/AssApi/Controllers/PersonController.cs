using AssApi.Dtos;
using AssApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AssApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewPerson(AddPersonDto newPerson)
        {
            return Ok(await _personService.AddPerson(newPerson));
        }
        [HttpPut] 
        public async Task<IActionResult> EditPerson(EditPersonDto edit)
        {
            return Ok(await _personService.EditPerson(edit));
        } 
        [HttpDelete] 
        public async Task<IActionResult> DeletePerson(int id)
        {
            return Ok(await _personService.DeletePerson(id)); 

        }
        [HttpGet] 
        public async Task<IActionResult> GetPersons()
        {
            return Ok(await _personService.GetAllPerson());
        }
    }
}
