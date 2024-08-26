using MyRestApi.Features.UserAccounts.Models;

namespace MyRestApi.Features.BooksLibrary.DTOs
{
    public class BookDto
    {
        // Book ID (Primary Key)
        public int ID { get; set; }

        // Book Title
        public string Title { get; set; }

        // Book Author
        public string Author { get; set; }

        // Book Genre
        public string Genre { get; set; }

        // Quantity of Inventory
        public int Quantity { get; set; }

        // Checked Out Status
        public bool CheckedOut { get; set; }

        // User ID of the User Who Checked Out Book
        public User? CheckedOutUserId { get; set; }

        // Release Date
        public DateTime ReleaseDate { get; set; }

        // Due Date
        public DateTime? DueDate { get; set; }
    }
}
