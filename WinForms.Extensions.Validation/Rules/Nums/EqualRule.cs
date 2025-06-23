using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class EqualRule : IValidationRule<int>
    {
        private readonly int _value;
        private readonly string _message;
        public EqualRule(int value, string? message = null)
        {
            _value = value;
            _message = message ?? $"Value must be equal to {_value}.";
        }
        public ValidationResult Validate(int value)
        {
            if (value != _value)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
    }
}
