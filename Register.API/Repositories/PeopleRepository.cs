using Microsoft.EntityFrameworkCore;
using Register.API.Data;
using Register.API.Entities;

namespace Register.API.Repositories;

public class PeopleRepository(APIDbContext context) : IPeopleRepository
{
    private readonly APIDbContext _context = context;

    public async Task<List<People>> GetAll() =>
                        await _context.People.Include(x => x.Phone).ToListAsync();

    public async Task<People> GetPersonByName(string Name)
    {
        var person = await _context.People.FirstOrDefaultAsync(x => x.Name.Contains(Name));

        if (person == null)
        {
            return null!;
        }

        return person;
    }

    public async Task<People> GetPersonById(int Id)
    {
        var person = await _context.People.FirstOrDefaultAsync(x => x.Id == Id);
        if (person is null) return null!;
        return person;
    }

    public async Task<People> NewPerson(People Person)
    {
        if (Person == null) return null!;

        var newPerson = _context.People.Add(Person).Entity;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message);
        }

        return newPerson;
    }

    public async Task<People> UpdatePerson(People Person)
    {
        var person = await _context.People.FirstOrDefaultAsync(x => x.Id == Person.Id);

        person = Person;

        _context.Entry(person).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message);
        }

        return await _context.People.FirstOrDefaultAsync(x => x.Id == Person.Id);
    }

    public async Task<People> DeletePerson(int Id)
    {
        var person = await _context.People.FindAsync(Id);

        if (person == null) return null!;

        _context.People.Remove(person);
        await _context.SaveChangesAsync();

        return person;
    }
}