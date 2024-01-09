using Microsoft.EntityFrameworkCore;
using Register.API.Entities;

namespace Register.API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<People> People { get; set; }

        public DbSet<Phones> Phones { get; set; }
    }
}
