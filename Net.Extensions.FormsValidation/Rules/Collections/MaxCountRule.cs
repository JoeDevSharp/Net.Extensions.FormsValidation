using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class MaxCountRule : IValidationRule<ICollection<object>>
    {
        private readonly int _maxCount;
        private readonly string _message;
        public MaxCountRule(int maxCount, string? message = null)
        {
            _maxCount = maxCount;
            _message = message ?? $"Collection must not exceed {_maxCount} items.";
        }
        public ValidationResult Validate(ICollection<object> value)
        {
            if (value == null || value.Count > _maxCount)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
