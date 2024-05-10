using api.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace api.Dto.Account
{
    public class LoginDto
    {
        [Required, StudentIdValidation]
        public required int StudentId { get; set; }

        [Required, PasswordValidation]
        public required string Password { get; set; }
    }
}
