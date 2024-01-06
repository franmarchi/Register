using System.ComponentModel.DataAnnotations;

namespace Register.API.Entities
{
    public class Phones
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo Tipo do Telefone é Obrigatório!")]
        public required string PhoneType { get; set; }

        [Required(ErrorMessage = "O campo Número é Obrigatório!")]
        public required string PhoneNumber { get; set; }

    }

}
