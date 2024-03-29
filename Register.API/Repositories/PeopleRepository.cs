﻿using Microsoft.EntityFrameworkCore;
using Register.API.Data;
using Register.API.Entities;
using System;

namespace Register.API.Repositories;

public class PeopleRepository : IPeopleRepository
{
    private readonly APIDbContext _context;

    public PeopleRepository(APIDbContext context)
    {
        _context = context;
    }


    public async Task<List<People>> GetAll() =>
                        await _context.People.Include(x => x.Phone).ToListAsync();

    public async Task<People> GetPersonById(int Id)
    {
        var person = await _context.People.Include(x => x.Phone).FirstOrDefaultAsync(x => x.Id == Id);
        if (person is null) return null!;
        return person;
    }

    public async Task<People> NewPerson(People Person)
    {
        if (Person == null) return null!;

        var newPerson = _context.People.Add(Person).Entity;

        await _context.SaveChangesAsync();

        return newPerson;
    }

    public async Task<People> UpdatePerson(People Person)
    {
        var person = await _context.People.Include(x => x.Phone).FirstOrDefaultAsync(x => x.Id == Person.Id);

        person.Name = Person.Name;
        person.Phone.PhoneNumber = Person.Phone.PhoneNumber;
        person.Phone.PhoneType = Person.Phone.PhoneType;
        person.IsActive = Person.IsActive;

        await _context.SaveChangesAsync();

        return await _context.People.FirstOrDefaultAsync(x => x.Id == Person.Id);
    }

    public async Task<People> DeletePerson(int Id)
    {
        var person = await _context.People.Include(x => x.Phone).FirstOrDefaultAsync(x => x.Id == Id);

        if (person == null) return null!;

        _context.People.Remove(person);
        await _context.SaveChangesAsync();

        return person;
    }
}