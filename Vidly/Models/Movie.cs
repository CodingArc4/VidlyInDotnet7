using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre? Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        [Required]
        public byte NumberInStock { get; set; }
    }
}
