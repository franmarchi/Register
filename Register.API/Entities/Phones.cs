using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.API.Entities
{
    public class Phones
    {
        [Key]
        public int Id { get; set; }
        
        public string PhoneNumber { get; set; } = string.Empty;

    }

}
