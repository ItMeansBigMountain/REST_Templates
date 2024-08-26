using MyRestApi.Features.UserAccounts.DTOs;
using MyRestApi.Features.UserAccounts.Services;
using MyRestApi.Features.UserAccounts.Data;
using MyRestApi.Features.UserAccounts.Models;
using MyRestApi.Features.BooksLibrary.DTOs;
using MyRestApi.Features.BooksLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRestApi.Features.UserAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserAccountsController(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        // GET: api/UserAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOutputDto>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = new List<UserOutputDto>();

            foreach (var user in users)
            {
                var checkedOutBookDtos = new List<BookDto>();
                foreach (var book in user.CheckedOutBooks)
                {
                    checkedOutBookDtos.Add(new BookDto
                    {
                        ID = book.ID,
                        Title = book.Title,
                        Author = book.Author,
                        Genre = book.Genre,
                        Quantity = book.Quantity,
                        CheckedOut = book.CheckedOut,
                        ReleaseDate = book.ReleaseDate,
                        DueDate = book.DueDate
                    });
                }

                userDtos.Add(new UserOutputDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = user.Role,
                    RegisteredAt = user.RegisteredAt,
                    CheckedOutBooks = checkedOutBookDtos.ToList()
                });
            }

            return Ok(userDtos);
        }

        // GET: api/UserAccounts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOutputDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var checkedOutBookDtos = new List<BookDto>();
            foreach (var book in user.CheckedOutBooks)
            {
                checkedOutBookDtos.Add(new BookDto
                {
                    ID = book.ID,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Quantity = book.Quantity,
                    CheckedOut = book.CheckedOut,
                    ReleaseDate = book.ReleaseDate,
                    DueDate = book.DueDate
                });
            }

            var userDto = new UserOutputDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                RegisteredAt = user.RegisteredAt,
                CheckedOutBooks = checkedOutBookDtos.ToList() // Convert to array
            };

            return Ok(userDto);
        }

        // POST: api/UserAccounts
        [HttpPost]
        public async Task<ActionResult<UserOutputDto>> AddUser(UserInputDto userDto)
        {
            var hashedPassword = _passwordService.HashPassword(userDto.Password);
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = hashedPassword,
                Role = userDto.Role,
                CheckedOutBooks = new List<Book>(), // Initialize as empty list
                RegisteredAt = userDto.RegisteredAt
            };

            await _userRepository.AddAsync(user);

            var addedUserDto = new UserOutputDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                RegisteredAt = user.RegisteredAt,
                CheckedOutBooks = new List<BookDto> { }
            };

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, addedUserDto);
        }

        // PUT: api/UserAccounts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserInputDto userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            var hashedPassword = _passwordService.HashPassword(userDto.Password);

            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Email = userDto.Email;
            existingUser.Password = hashedPassword;
            existingUser.Role = userDto.Role;

            if (existingUser.CheckedOutBooks == null)
            {
                existingUser.CheckedOutBooks = new List<Book>();
            }

            if (userDto.CheckedOutBooks != null)
            {
                existingUser.CheckedOutBooks.Clear(); // Clear existing list
                foreach (var bookDto in userDto.CheckedOutBooks)
                {
                    existingUser.CheckedOutBooks.Add(new Book
                    {
                        ID = bookDto.ID,
                        Title = bookDto.Title,
                        Author = bookDto.Author,
                        Genre = bookDto.Genre,
                        Quantity = bookDto.Quantity,
                        CheckedOut = bookDto.CheckedOut,
                        ReleaseDate = bookDto.ReleaseDate,
                        DueDate = bookDto.DueDate,
                        CheckedOutUserId = bookDto.CheckedOutUserId // Setting the User who checked out the book
                    });
                }
            }

            existingUser.RegisteredAt = userDto.RegisteredAt;

            await _userRepository.UpdateAsync(existingUser);

            return NoContent();
        }


        // DELETE: api/UserAccounts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
