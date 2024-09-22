using System.ComponentModel.DataAnnotations;

namespace MVCWeek10Project.Models
{
    public class Book
    {
        public int Id { get; set; }  // Unique identifier for the book

        [Required]
        [StringLength(100)]
        public string Title { get; set; }  // Title of the book

        public int AuthorId { get; set; }  // Foreign key for the Author

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }  // Genre or type of book

        [Required]
        public DateTime PublishDate { get; set; }  // Publish date

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }  // ISBN number

        [Required]
        [Range(0, int.MaxValue)]
        public int CopiesAvailable { get; set; }  // Number of copies available
    }

}

