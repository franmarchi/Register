using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Register.API.Data;
using Register.API.Entities;

namespace Register.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController(APIDbContext context) : ControllerBase
    {
        private readonly APIDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var Person = await _context.People.FindAsync(id);

            if (Person == null)
            {
                return NotFound();
            }

            return Person;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPeople(Person Person)
        {
            _context.People.Add(Person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new { id = Person.Id }, Person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            var Person = await _context.People.FindAsync(id);
            if (Person == null)
            {
                return NotFound();
            }

            _context.People.Remove(Person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
