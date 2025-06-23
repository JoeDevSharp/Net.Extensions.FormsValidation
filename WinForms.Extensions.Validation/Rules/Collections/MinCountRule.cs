using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class MinCountRule : IValidationRule<ICollection<object>>
    {
        private readonly int _minCount;
        private readonly string _message;
        public MinCountRule(int minCount, string? message = null)
        {
            _minCount = minCount;
            _message = message ?? $"Collection must contain at least {_minCount} items.";
        }
        public ValidationResult Validate(ICollection<object> value)
        {
            if (value == null || value.Count < _minCount)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
