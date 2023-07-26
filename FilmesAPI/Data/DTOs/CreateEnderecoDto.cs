using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class CreateEnderecoDTO
    {
        [Required(ErrorMessage = "O logradouro é obrigatório")]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}