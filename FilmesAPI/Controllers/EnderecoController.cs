using FilmesAPI.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesApi.Data;
using AutoMapper;

namespace FilmesAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EnderecoController : ControllerBase
  {
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
    {
      var endereco = _mapper.Map<Endereco>(enderecoDTO);
      _context.Enderecos.Add(endereco);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetEnderecoById), new { Id = endereco.Id }, enderecoDTO);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDTO> GetEnderecos()
    {
      return _mapper.Map<List<ReadEnderecoDTO>>(_context.Enderecos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetEnderecoById(int id)
    {
      var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
      if (endereco != null)
      {
        var enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);
        return Ok(enderecoDTO);
      }
      return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
    {
      var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
      if (endereco == null)
      {
        return NotFound();
      }
      _mapper.Map(enderecoDTO, endereco);
      _context.SaveChanges();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEndereco(int id)
    {
      var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
      if (endereco == null)
      {
        return NotFound();
      }
      _context.Remove(endereco);
      _context.SaveChanges();
      return NoContent();
    }
  }
}