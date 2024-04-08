namespace api.Dto;

public class StudentDto{
    public required int StudentId { get; set; }
    public required string Email { get; set; }
    public required string FullName { get; set; }
    public required string Password { get; set; }
    public required string Group { get; set; }
}
