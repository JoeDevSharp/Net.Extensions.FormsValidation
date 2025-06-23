using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class StartsWithRule : IValidationRule<string>
    {
        private readonly string _prefix;
        private readonly string _message;
        public StartsWithRule(string prefix, string? message = null)
        {
            _prefix = prefix;
            _message = message ?? $"Value must start with '{_prefix}'.";
        }
        public ValidationResult Validate(string value)
        {
            if (value == null) value = string.Empty;
            if (!value.StartsWith(_prefix))
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
