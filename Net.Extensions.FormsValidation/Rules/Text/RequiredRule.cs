using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class RequiredRule<T> : IValidationRule<T>
    {
        private readonly string _message;

        public RequiredRule(string? message = null)
        {
            _message = message ?? "Is Required";
        }

        public ValidationResult Validate(T value)
        {
            if (value == null)
                return ValidationResult.Fail(_message);

            if (value is string s && string.IsNullOrWhiteSpace(s))
                return ValidationResult.Fail(_message);

            return ValidationResult.Success();
        }
    }
}
