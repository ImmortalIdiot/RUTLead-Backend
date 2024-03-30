namespace api.Models;

public class Student
{
    Student(string? studentId, string? email, string? fullName, string? password)
    {
        StudentId = studentId;
        Email = email;
        FullName = fullName;
        Password = password;
    }
    
    public string? StudentId { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? Password { get; set; }
}
