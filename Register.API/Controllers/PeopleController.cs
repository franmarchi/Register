using Microsoft.AspNetCore.Mvc;
using Register.API.Entities;
using Register.API.Repositories;

namespace Register.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PeopleController(IPeopleRepository peopleRepository) : ControllerBase
    {
        private readonly IPeopleRepository peopleRepository = peopleRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetAll()
        {
            var people = await peopleRepository.GetAll();
            return Ok(people);
        }

        [HttpGet("Person/{id}")]
        public async Task<ActionResult<List<People>>> GetPersonById(int id)
        {
            var person = await peopleRepository.GetPersonById(id);
            return Ok(person);
        }

        [HttpPost("NewPerson")]
        public async Task<ActionResult<People>> NewPerson(People Person)
        {
            var person = await peopleRepository.NewPerson(Person);

            return Ok(person);
        }

        [HttpPut("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson(People Person)
        {
            var person = await peopleRepository.UpdatePerson(Person);
            
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await peopleRepository.DeletePerson(id);

            return Ok(person);
        }
    }
}
