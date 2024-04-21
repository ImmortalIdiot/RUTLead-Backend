using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api.Dto.Account
{
    public class LoginDto
    {
        [Required]
        public required int StudentId { get; set; }
        
        [Required]
        public required string Password { get; set; }
    }
}
