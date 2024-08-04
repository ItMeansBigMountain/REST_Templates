namespace MyRestApi.Features.UserAccounts.Models
{
    public class User
    {
        // User ID (Primary Key)
        public int Id { get; set; }
        
        // User's First Name
        public string FirstName { get; set; }
        
        // User's Last Name
        public string LastName { get; set; }
        
        // User's Email Address
        public string Email { get; set; }
        
        // User's Password
        public string Password { get; set; }
        
        // User's Role (e.g., Admin, Member)
        public string Role { get; set; }
        
        // Date and Time the User Registered
        public DateTime RegisteredAt { get; set; }
    }
}
