using System.ComponentModel.DataAnnotations.Schema;

namespace BooksSpring2024_sec02.Models
{
    public class Cart
    {

        public int CartId { get; set; }
        public int BookId { get; set; }
        
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int Quantity { get; set; }

    }
}
