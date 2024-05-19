using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.DataAnnotations 
{
    public class PasswordValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? password, ValidationContext validationContext)
        {
            var passwordString = password != null ? password.ToString() : null;

            if (string.IsNullOrWhiteSpace(passwordString) || passwordString.Length < 6) return new ValidationResult("Password length must be at least 6 characters");

            if (!passwordString.Any(char.IsDigit)) return new ValidationResult("The password must have at least 1 digit");

            if (!Regex.IsMatch(passwordString, @"[!@#$%^&*()_+}{'?/><|~`]")) return new ValidationResult("Password must have at least one non alphanumeric character");

            if (!passwordString.Any(ch => char.IsLower(ch) && ch >= 'a' && ch <= 'z')) return new ValidationResult("Password must have at least one lowercase ('a'-'z')");

            if (!passwordString.Any(ch => char.IsUpper(ch) && ch >= 'A' && ch <= 'Z')) return new ValidationResult(" Password must have at least one uppercase ('A'-'Z')");

            return ValidationResult.Success;
        }
    }
}
