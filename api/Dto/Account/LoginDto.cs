using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api.Dto.Account
{
    public class LoginDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
