namespace api.Dto.Account;

public class NewUserDto
{
    public required int StudentId { get; set; }
    public required string Email { get; set; }
    public required string FullName { get; set; }
    public required string Group { get; set; }
    public required string Token { get; set; }
}
