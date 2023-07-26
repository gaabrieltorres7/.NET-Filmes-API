using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using FilmesApi.Data;

namespace FilmesApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CinemaController : ControllerBase
  {
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateCinema([FromBody] CreateCinemaDTO cinemaDTO)
    {
      var cinema = _mapper.Map<Cinema>(cinemaDTO);
      _context.Cinemas.Add(cinema);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetCinemaById), new { Id = cinema.Id }, cinemaDTO);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDTO> GetCinemas()
    {
      return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCinemaById(int id)
    {
      var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
      if (cinema != null)
      {
        var cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
        return Ok(cinemaDTO);
      }
      return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
    {
      var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
      if (cinema == null)
      {
        return NotFound();
      }
      _mapper.Map(cinemaDTO, cinema);
      _context.SaveChanges();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
      var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
      if (cinema == null)
      {
        return NotFound();
      }
      _context.Remove(cinema);
      _context.SaveChanges();
      return NoContent();
    }
  }
}
