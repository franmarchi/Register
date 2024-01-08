using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Register.API.Entities
{
    public class People
    {
        public People() { }
        public People(string name) { Name = name; }

        [Key]
        public int Id { get; set; }

        public string? CPF { get; set; }

        public string? Name { get; set; }
        
        public DateOnly BirthDate { get; set; }

        public Phones Phone { get; set; } = new Phones();
        
        public bool IsActive { get; set; }
    }
}
