using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class GreaterThanRule : IValidationRule<int>
    {
        private readonly int _threshold;
        private readonly string _message;
        public GreaterThanRule(int threshold, string? message = null)
        {
            _threshold = threshold;
            _message = message ?? $"Value must be greater than {_threshold}.";
        }
        public ValidationResult Validate(int value)
        {
            if (value <= _threshold)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
