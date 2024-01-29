using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksSpring2024_sec02.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } //navigational property
    }
}
