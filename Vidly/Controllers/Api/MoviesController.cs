using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //endpoint to get
        [HttpGet("GetMovies")]
        public IActionResult GetAllMovies()
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
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
            return Ok(movies);
        }

        //endpoint to create 
        [HttpPost("CreateMovie")]
        public IActionResult CreateMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }

            _context.Add(movie);
            _context.SaveChanges();
            return Ok();
        }

        //endpoint to update 
        [HttpPut("UpdateMovie/{id}")]
        public IActionResult EditMovie(int id, [FromBody] Movie movie)
        {

            var moviesInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (moviesInDb == null)
            {
                return NotFound();
            }

            moviesInDb.Name = movie.Name;
            moviesInDb.ReleaseDate = movie.ReleaseDate;
            moviesInDb.NumberInStock = movie.NumberInStock;
            moviesInDb.DateAdded = DateTime.Now;

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
