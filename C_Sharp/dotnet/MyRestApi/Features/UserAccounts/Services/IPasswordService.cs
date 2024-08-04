namespace MyRestApi.Features.UserAccounts.Services
{
    // SERVICES ARE FOR SUB-FEATURES WITHIN THE FEATURE
    // EXAMPLES INCLUDE: PASSWORD ENCRYPTION, EMAIL NOTIFICATIONS, FILE UPLOADS
    
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}
