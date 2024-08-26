using MyRestApi.Features.BooksLibrary.Models;

namespace MyRestApi.Features.UserAccounts.Models
{
    public class User
    {
        // User ID (Primary Key)
        public int Id { get; set; }
        
        // User's First Name
        public required string FirstName { get; set; }
        
        // User's Last Name
        public required string LastName { get; set; }
        
        // User's Email Address
        public required string Email { get; set; }
        
        // User's Password
        public required string Password { get; set; }
        
        // User's Role (e.g., Admin, Member)
        public required string Role { get; set; }
        
        // Date and Time the User Registered
        public required DateTime RegisteredAt { get; set; }

        // Books User has checked out
        public List<Book>? CheckedOutBooks { get; set; } = new List<Book>(); // Updated to ICollection for EF
    }
}
