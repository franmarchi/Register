using Microsoft.EntityFrameworkCore;
using Register.API.Entities;

namespace Register.API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }

        public DbSet<Phones> Phones { get; set; }

        public DbSet<PhoneTypes> PhoneTypes { get; set; }

    }
}
