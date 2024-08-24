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
        // SERVICES IMPORT
        private IBooksLibraryRepository _booksRepository;

        public BooksLibraryController(IBooksLibraryRepository bookRepository)
        {
            _booksRepository = bookRepository;
        }

        // GET: api/BooksLibrary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _booksRepository.GetAllAsync();
            var bookDtos = new List<BookDto>();

            foreach (var book in books)
            {
                bookDtos.Add(new BookDto
                {
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Quantity = book.Quantity,
                    CheckedOut = book.CheckedOut,
                    ReleaseDate = book.ReleaseDate,
                    DueDate = book.DueDate
                });
            }
            return Ok(bookDtos);
        }

        // GET: api/BooksLibrary/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _booksRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = new BookDto
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Quantity = book.Quantity,
                CheckedOut = book.CheckedOut,
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
                CheckedOut = bookDto.CheckedOut,
                ReleaseDate = bookDto.ReleaseDate,
                DueDate = bookDto.DueDate
            };

            await _booksRepository.AddAsync(book);

            bookDto.Id = book.Id;

            return CreatedAtAction(nameof(GetBookById), new { id = bookDto.Id }, bookDto);
        }

        // PUT: api/BooksLibrary/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            var existingBook = await _booksRepository.GetByIdAsync(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = bookDto.Title;
            existingBook.Author = bookDto.Author;
            existingBook.Genre = bookDto.Genre;
            existingBook.Quantity = bookDto.Quantity;
            existingBook.CheckedOut = bookDto.CheckedOut;
            existingBook.ReleaseDate = bookDto.ReleaseDate;
            existingBook.DueDate = bookDto.DueDate;

            await _booksRepository.UpdateAsync(existingBook);

            return NoContent();
        }

        // DELETE: api/BooksLibrary/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _booksRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await _booksRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
