using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class MustBeTrueRule : IValidationRule<bool>
    {
        private readonly string _message;
        public MustBeTrueRule(string? message = null)
        {
            _message = message ?? "Value must be true.";
        }
        public ValidationResult Validate(bool value)
        {
            if (!value)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
