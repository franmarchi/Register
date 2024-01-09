using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register.API.Entities
{
    public class Phones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
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
