using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class MinLengthRule : IValidationRule<string>
    {
        private readonly int _min;
        private readonly string _message;
        public MinLengthRule(int min, string? message = null)
        {
            _min = min;
            _message = message ?? $"Length must be at least {_min} characters.";
        }
        public ValidationResult Validate(string value)
        {
            if (value == null) value = string.Empty;
            if (value.Length < _min)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
