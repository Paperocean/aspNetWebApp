using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Components
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime RelaseDate { get; set; } = DateTime.Today;

        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
        public double Rate { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Genres")]
        public string Genres { get; set; } = string.Empty;
    }
}
