using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime RelaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20, ErrorMessage = "The number of stock must be between 1 and 20")]
        public int NumberInStock { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}
