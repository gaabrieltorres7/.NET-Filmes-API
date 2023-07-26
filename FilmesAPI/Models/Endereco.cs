using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
  public class Endereco
  {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O logradouro é obrigatório")]
    public string Logradouro { get; set; }
    public int Numero { get; set; }
  }
}