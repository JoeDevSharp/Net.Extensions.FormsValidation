using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class MaxLengthRule : IValidationRule<string>
    {
        private readonly int _max;
        private readonly string _message;
        public MaxLengthRule(int max, string? message = null)
        {
            _max = max;
            _message = message ?? $"Length must not exceed {_max} characters.";
        }
        public ValidationResult Validate(string value)
        {
            if (value == null) value = string.Empty;
            if (value.Length > _max)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
