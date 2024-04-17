using Microsoft.AspNetCore.Identity;

namespace api.Models{
    public class AppUser : IdentityUser
    {
        public required int StudentId { get; set; }
        public required string Group { get; set; }
    }
}