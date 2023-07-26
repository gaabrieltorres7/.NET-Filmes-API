using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O nome do cinema é obrigatório")]
        public string Nome { get; set; }
    }
}