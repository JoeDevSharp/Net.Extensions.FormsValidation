using JoeDevSharp.WinForms.Extensions.Validation.Enums;

namespace JoeDevSharp.WinForms.Extensions.Validation
{

    public class ValidationResult
    {
        public bool IsValid => Severity == null;
        public ValidationSeverity? Severity { get; }
        public string Message { get; }

        public ValidationResult()
        {
            Severity = null;
            Message = string.Empty;
        }

        public ValidationResult(ValidationSeverity severity, string message)
        {
            Severity = severity;
            Message = message;
        }

        public static ValidationResult Success() => new ValidationResult();

        public static ValidationResult Fail(string message, ValidationSeverity severity = ValidationSeverity.Error)
            => new ValidationResult(severity, message);
    }
}
