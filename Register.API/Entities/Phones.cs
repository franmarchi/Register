using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Register.API.Entities
{
    public class Phones
    {
        [Key]
        public int Id { get; set; }

        public string? PhoneType { get; set; }

        public string? PhoneNumber { get; set; }

    }

    public enum PhoneTypes
    {
        [Description("Celular")]
        Celular,
        
        [Description("Residencial")]
        Residencial,
        
        [Description("Comercial")]
        Comercial,

    }

}
