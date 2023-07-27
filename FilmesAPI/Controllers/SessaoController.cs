using AutoMapper;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data.DTOs;

namespace FilmesApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SessaoController : ControllerBase
  {
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
    {
      Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
      _context.Sessoes.Add(sessao);
      _context.SaveChanges();
      return CreatedAtAction(nameof(RecuperaSessaoPorId), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, sessao);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> RecuperaSessoes()
    {
      return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
    }

    [HttpGet("{filmeId}/{cinemaId}")]
    public IActionResult RecuperaSessaoPorId(int filmeId, int cinemaId)
    {
      Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
      if (sessao != null)
      {
        ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
        return Ok(sessaoDto);
      }
      return NotFound();
    }
  }
}