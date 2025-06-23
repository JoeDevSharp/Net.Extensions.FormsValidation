using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class LengthRule : IValidationRule<string>
    {
        private readonly int? _min;
        private readonly int? _max;
        private readonly string _message;

        public LengthRule(int? min = null, int? max = null, string? message = null)
        {
            _min = min;
            _max = max;
            _message = message ?? $"Length must be between {_min} and {_max} characters.";
        }

        public ValidationResult Validate(string value)
        {
            if (value == null) value = string.Empty;

            if (_min.HasValue && value.Length < _min.Value)
                return ValidationResult.Fail(_message);

            if (_max.HasValue && value.Length > _max.Value)
                return ValidationResult.Fail(_message);

            return ValidationResult.Success();
        }
    }
}
