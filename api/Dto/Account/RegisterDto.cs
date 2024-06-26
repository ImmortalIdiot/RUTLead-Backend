using System.ComponentModel.DataAnnotations;
using api.DataAnnotations;

namespace api.Dto.Account
{
    public class RegisterDto
    {
        [Required, StudentIdValidation]
        public int StudentId { get; set; }
        
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required, RegularExpression(@"^[А-ЯЁ][а-яё]+(?:\s[А-ЯЁ][а-яё]+){2}(?:\s[а-яё]+)?$", ErrorMessage = "Incorrect username")]
        public required string FullName { get; set; }

        [Required, PasswordValidation]
        public required string Password { get; set; }

        [Required, RegularExpression(@"^[А-ЯЁ]{3}[а-яё]{0,2}-\d{3}$", ErrorMessage = "Incorrect  user group")]
        public required string Group { get; set; }
    }
}
