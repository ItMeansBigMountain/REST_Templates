using MyRestApi.Features.BooksLibrary.Models;


namespace MyRestApi.Features.BooksLibrary.Data
{
    public interface IBooksLibraryRepository
    {
        // GET ALL BOOKS
        Task<IEnumerable<Book>> GetAllAsync();
        
        // GET BOOKS BY ID
        Task<Book> GetByIdAsync(int id);
        
        // ADD NEW BOOK
        Task AddAsync(Book book);
        
        // UPDATE EXISTING BOOK
        Task UpdateAsync(Book book);
        
        // DELETE BOOK
        Task DeleteAsync(int id);
    }
}
