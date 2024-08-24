using Microsoft.EntityFrameworkCore;
using MyRestApi.Infrastructure;
using MyRestApi.Features.BooksLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRestApi.Features.BooksLibrary.Data
{
    public class BooksLibraryRepository : IBooksLibraryRepository
    {
        private readonly AppDbContext _context;

        public BooksLibraryRepository(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL BOOKS
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        // GET BOOKS BY ID
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        // ADD NEW BOOKS
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        // UPDATE EXISTING BOOK
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        // DELETE BOOK
        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
