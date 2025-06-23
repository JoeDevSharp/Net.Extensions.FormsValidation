using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class EmailRule : IValidationRule<string>
    {
        private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private readonly string _message;
        public EmailRule(string? message = null)
        {
            _message = message ?? "Invalid email format.";
        }
        public ValidationResult Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return ValidationResult.Fail(_message);
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, EmailPattern))
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
