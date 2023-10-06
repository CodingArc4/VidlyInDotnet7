using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFromViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }    
    }
}
