using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class EndsWithRule : IValidationRule<string>
    {
        private readonly string _suffix;
        private readonly string _message;
        public EndsWithRule(string suffix, string? message = null)
        {
            _suffix = suffix;
            _message = message ?? $"Value must end with '{_suffix}'.";
        }
        public ValidationResult Validate(string value)
        {
            if (value == null) value = string.Empty;
            if (!value.EndsWith(_suffix))
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
