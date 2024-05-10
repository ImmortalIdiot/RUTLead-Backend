using api.Enums;
namespace api.Models;
public class Student {
    public required int StudentId { get; set; } 
    public required string Email { get; set; }
    public required string FullName { get; set; }
    public required string PasswordHash { get; set; }
    public required string Group { get; set; }
    public Roles Role { get; set; }
}
