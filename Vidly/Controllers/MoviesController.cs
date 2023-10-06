using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        //action method for new movie
        public IActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFromViewModel
            {
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }


        //action method to add/edit movie
        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                //Mapper.Map(customer,customerInDb)

                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        //action method to edit movie
        public IActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return NotFound();

            var viewModel = new MovieFromViewModel
            {
                Movie = movies,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                movie = movie,
                customers = customers
            };

            return View(viewModel);
        }
    }
}