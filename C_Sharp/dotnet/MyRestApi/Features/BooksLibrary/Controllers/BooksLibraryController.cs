using MyRestApi.Features.BooksLibrary.DTOs;
using MyRestApi.Features.BooksLibrary.Data;
using MyRestApi.Features.BooksLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyRestApi.Features.BooksLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksLibraryController : ControllerBase
    {
        private readonly IBooksLibraryRepository _booksRepository;

        public BooksLibraryController(IBooksLibraryRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET: api/BooksLibrary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _booksRepository.GetAllAsync();
            var bookDtos = books.Select(book => new BookDto
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Quantity = book.Quantity,
                CheckedOut = book.CheckedOut,
                CheckedOutUserId = book.CheckedOutUserId, // Mapping the user who checked out the book
                ReleaseDate = book.ReleaseDate,
                DueDate = book.DueDate
            }).ToList();

            return Ok(bookDtos);
        }

        // GET: api/BooksLibrary/{ID}
        [HttpGet("{ID}")]
        public async Task<ActionResult<BookDto>> GetBookByID(int ID)
        {
            var book = await _booksRepository.GetByIdAsync(ID);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = new BookDto
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Quantity = book.Quantity,
                CheckedOut = book.CheckedOut,
                CheckedOutUserId = book.CheckedOutUserId, // Mapping the user who checked out the book
                ReleaseDate = book.ReleaseDate,
                DueDate = book.DueDate
            };

            return Ok(bookDto);
        }

        // POST: api/BooksLibrary
        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                Quantity = bookDto.Quantity,
                CheckedOut = false, // New books should not be checked out
                CheckedOutUserId = null, // No user should be associated with a new book
                ReleaseDate = bookDto.ReleaseDate,
                DueDate = bookDto.DueDate
            };

            await _booksRepository.AddAsync(book);

            bookDto.ID = book.ID;

            return CreatedAtAction(nameof(GetBookByID), new { ID = bookDto.ID }, bookDto);
        }

        // PUT: api/BooksLibrary/{ID}
        [HttpPut("{ID}")]
        public async Task<IActionResult> UpdateBook(int ID, BookDto bookDto)
        {
            var existingBook = await _booksRepository.GetByIdAsync(ID);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = bookDto.Title;
            existingBook.Author = bookDto.Author;
            existingBook.Genre = bookDto.Genre;
            existingBook.Quantity = bookDto.Quantity;
            existingBook.CheckedOut = bookDto.CheckedOut;
            existingBook.CheckedOutUserId = bookDto.CheckedOutUserId; // Updating the user who checked out the book
            existingBook.ReleaseDate = bookDto.ReleaseDate;
            existingBook.DueDate = bookDto.DueDate;

            await _booksRepository.UpdateAsync(existingBook);

            return NoContent();
        }

        // DELETE: api/BooksLibrary/{ID}
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteBook(int ID)
        {
            var book = await _booksRepository.GetByIdAsync(ID);

            if (book == null)
            {
                return NotFound();
            }

            await _booksRepository.DeleteAsync(ID);

            return NoContent();
        }
    }
}
