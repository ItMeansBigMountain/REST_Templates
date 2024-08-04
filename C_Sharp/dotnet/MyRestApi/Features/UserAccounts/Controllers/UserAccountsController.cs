using MyRestApi.Features.UserAccounts.DTOs;
using MyRestApi.Features.UserAccounts.Services;
using MyRestApi.Features.UserAccounts.Data;
using MyRestApi.Features.UserAccounts.Models;
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
                userDtos.Add(new UserOutputDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = user.Role,
                    RegisteredAt = user.RegisteredAt
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

            var userDto = new UserOutputDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                RegisteredAt = user.RegisteredAt
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
                RegisteredAt = userDto.RegisteredAt
            };

            await _userRepository.AddAsync(user);

            userDto.Id = user.Id;

            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
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
