using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.API.Entities
{
    public class PhoneTypes
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="O campo é Obrigatório!")]
        public  required string Name { get; set; }
    }
}
