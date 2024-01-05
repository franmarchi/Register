using System.ComponentModel.DataAnnotations;

namespace Register.API.Entities
{
    public class Phones
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo Tipo do Telefone é Obrigatório!")]
        public required PhoneTypes PhoneType { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;
    }

}
