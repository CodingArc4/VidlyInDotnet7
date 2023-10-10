using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //endpoint to get
        [HttpGet("GetMovies")]
        public IActionResult GetAllMovies()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList();
            var movieDto = _mapper.Map<List<Movie>, List<MovieDto>>(movies);
            return Ok(movieDto);
        }

        //endpoint to get  by id
        [HttpGet("GetMovieById/{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movies = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movies == null)
            {
                return NotFound();
            }

            var moviesDto = _mapper.Map<Movie, MovieDto>(movies);
            return Ok(moviesDto);
        }

        //endpoint to create 
        [HttpPost("CreateMovie")]
        public IActionResult CreateMovie([FromBody] MovieDto movieDto)
        {
            if (movieDto == null)
            {
                return BadRequest();
            }

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Add(movie);
            _context.SaveChanges();
            return Ok();
        }

        //endpoint to update 
        [HttpPut("UpdateMovie/{id}")]
        public IActionResult EditMovie(int id, [FromBody] MovieDto movieDto)
        {

            var moviesInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (moviesInDb == null)
            {
                return NotFound();
            }

            _mapper.Map(movieDto, moviesInDb);

            //moviesInDb.Name = movieDto.Name;
            //moviesInDb.ReleaseDate = movieDto.ReleaseDate;
            //moviesInDb.NumberInStock = movieDto.NumberInStock;
            //moviesInDb.DateAdded = DateTime.Now;

            _context.Update(moviesInDb);
            _context.SaveChanges();
            return Ok();
        }

        //endpoint to  delete
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
