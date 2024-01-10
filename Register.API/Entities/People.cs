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

        [Required(ErrorMessage ="O Campo é obrigatório")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        public Phones Phone { get; set; } = new Phones();
        
        [Required(ErrorMessage ="O Campo é obrigatório")]
        public bool IsActive { get; set; }
    }
}
