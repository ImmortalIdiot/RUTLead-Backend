using api.Interfaces;
using api.Models;
using api.Dto.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.StudentId == loginDto.StudentId);

            if (user == null) return NotFound("Неверный номер студенческого билета!");

            var result = await _signManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return NotFound("Неверное имя пользователя или пароль!");

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

                var existingStudent = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == registerDto.StudentId.ToString());

                if (existingStudent != null) {
                    return BadRequest();
                }

                var appUser = new AppUser
                {
                    StudentId = registerDto.StudentId,
                    Group = registerDto.Group,
                    UserName = registerDto.FullName,
                    Email = registerDto.Email
                };

                var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Student");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                StudentId = registerDto.StudentId,
                                Group = registerDto.Group,
                                FullName = registerDto.FullName,
                                Email = registerDto.Email,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createUser.Errors);
                }
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
