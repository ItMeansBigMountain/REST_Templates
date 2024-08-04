using MyRestApi.Features.UserAccounts.Models;


namespace MyRestApi.Features.UserAccounts.Data
{
    public interface IUserRepository
    {
        // GET ALL USERS
        Task<IEnumerable<User>> GetAllAsync();
        
        // GET USER BY ID
        Task<User> GetByIdAsync(int id);
        
        // ADD NEW USER
        Task AddAsync(User user);
        
        // UPDATE EXISTING USER
        Task UpdateAsync(User user);
        
        // DELETE USER
        Task DeleteAsync(int id);
    }
}
