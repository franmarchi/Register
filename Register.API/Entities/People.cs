using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.API.Entities
{
    public class People
    {
        public People() { }
        public People(string name) { Name = name; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        public string? CPF { get; set; }

        public string? Name { get; set; }
        
        public DateOnly BirthDate { get; set; }

        public Phones? Phone { get; set; }
        
        public bool IsActive { get; set; }
    }
}
