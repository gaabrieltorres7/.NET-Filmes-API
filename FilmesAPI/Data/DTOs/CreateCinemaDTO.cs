using System.ComponentModel.DataAnnotations;
namespace FilmesAPI.Data.DTOs
{
  public class CreateCinemaDTO
  {
    [Required(ErrorMessage = "O nome do cinema é obrigatório")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
  }
}