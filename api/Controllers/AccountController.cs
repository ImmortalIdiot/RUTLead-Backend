using api.Interfaces;
using api.Models;
using api.Dto.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApiDBContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly IStudentRepository _studentManager;
        private readonly IPasswordHasher<Student> _passwordHasher;

        public AccountController(ITokenService tokenService, IPasswordHasher<Student> passwordHasher, IStudentRepository studentManager, ApiDBContext dbContext)
        {
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _studentManager = studentManager;
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == loginDto.StudentId);

            if (user == null) return NotFound("Invalid student ID number");

            var isPasswordHashValid = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

            if (isPasswordHashValid != PasswordVerificationResult.Success) return NotFound("Invalid username or password");

            try {
                return Ok(
                    new UserDto
                    {
                        StudentId = user.StudentId,
                        Token = _tokenService.CreateToken(user)
                    }
                );
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }   

                var existingStudent = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == registerDto.StudentId);

                if (existingStudent != null) {
                    return BadRequest("Such a user already exists");
                }

                var passwordHash = _passwordHasher.HashPassword(null!, registerDto.Password);

                var student = new Student
                {
                    StudentId = registerDto.StudentId,
                    Group = registerDto.Group,
                    FullName = registerDto.FullName,
                    Email = registerDto.Email,
                    PasswordHash = passwordHash
                };

                var createUser = await _studentManager.CreateAsync(student);
                
                return Ok(
                    new NewUserDto
                    {
                        StudentId = registerDto.StudentId,
                        Group = registerDto.Group,
                        FullName = registerDto.FullName,
                        Email = registerDto.Email,
                        Token = _tokenService.CreateToken(student)
                    }
                );
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
