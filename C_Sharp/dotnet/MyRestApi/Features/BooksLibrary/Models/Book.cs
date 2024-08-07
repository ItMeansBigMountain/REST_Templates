namespace MyRestApi.Features.BooksLibrary.Models
{
    public class Book
    {
        // User ID (Primary Key)
        public int Id { get; set; }

        // Book Title
        public required string Title { get; set; }

        // Book Author
        public required string Author { get; set; }

        // Book Genre
        public required string Genre { get; set; }

        // Quantity of Inventory
        public required int Quantity { get; set; }

        // Checked Out Status
        public required bool CheckedOut { get; set; }

        // Release Date
        public DateTime ReleaseDate { get; set; }

        // Due Date
        public DateTime DueDate { get; set; }
    }
}
