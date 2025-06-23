using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class GreaterOrEqualRule : IValidationRule<int>
    {
        private readonly int _threshold;
        private readonly string _message;
        public GreaterOrEqualRule(int threshold, string? message = null)
        {
            _threshold = threshold;
            _message = message ?? $"Value must be greater than or equal to {_threshold}.";
        }
        public ValidationResult Validate(int value)
        {
            if (value < _threshold)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
