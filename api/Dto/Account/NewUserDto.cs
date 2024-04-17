namespace api.Dto.Account;

public class NewUserDto
{
    public required int StudentId { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? Group { get; set; }
    public required string Token { get; set; }
}