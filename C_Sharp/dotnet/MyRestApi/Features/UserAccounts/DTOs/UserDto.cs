// What is a DTO (Data Transfer Object)?
// - Simple, data-only object used to transfer data between different parts of a system.
// - Encapsulates the data you want to expose through your API endpoints.
// - Contains only data fields (properties) without any business logic.
// - Often has a simpler structure than the domain models, sometimes combining data from multiple sources.
// - Designed for easy serialization and deserialization, making them suitable for transferring over a network.

// Why Use DTOs?
// - Encapsulation: Hides internal details, prevents over-exposure.
// - Performance: Transfers only necessary data.
// - Security: Exposes only non-sensitive information.
// - Decoupling: Allows internal changes without affecting API contract.

// THINK OF IT LIKE PYTHON DJANGO SERIALIZER CLASS

// WE'RE USING AN INPUT AND OUTPUT DTO TO RETURN THE USER JSON DATA OF THE USER SAFELY

using MyRestApi.Features.BooksLibrary.DTOs;

namespace MyRestApi.Features.UserAccounts.DTOs
{
    // INPUT DTO
    public class UserInputDto
    {
        // User ID
        public int Id { get; set; }

        // User's First Name
        public required string  FirstName { get; set; }

        // User's Last Name
        public required string LastName { get; set; }

        // User's Password
        public required string Password { get; set; }

        // User's Email Address
        public required string Email { get; set; }

        // User's Role (e.g., Admin, Member)
        public required string Role { get; set; }

        // Books User has checked out
        public List<BookDto>? CheckedOutBooks { get; set; }

        // Date and Time the User Registered
        public required DateTime RegisteredAt { get; set; }
    }

    // OUTPUT DTO
    public class UserOutputDto
    {
        // User ID
        public int Id { get; set; }

        // User's First Name
        public required string FirstName { get; set; }

        // User's Last Name
        public required string LastName { get; set; }

        // User's Email Address
        public required string Email { get; set; }

        // User's Role (e.g., Admin, Member)
        public required string Role { get; set; }

        // Books User has checked out
        public List<BookDto>? CheckedOutBooks { get; set; }

        // Date and Time the User Registered
        public required DateTime RegisteredAt { get; set; }
    }
}
