using JoeDevSharp.WinForms.Extensions.Validation;
using JoeDevSharp.WinForms.Extensions.Validation.Enums;
using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace WinFormsAppTest
{
    public class CustomRule<T> : IValidationRule<T>
    {
        private readonly Func<T, bool> _predicate;
        private readonly string _message;
        private readonly ValidationSeverity _severity;

        public CustomRule(Func<T, bool> predicate, string message, ValidationSeverity severity = ValidationSeverity.Error)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _message = message ?? throw new ArgumentNullException(nameof(message));
            _severity = severity;
        }

        public ValidationResult Validate(T value)
        {
            if (!_predicate(value))
                return ValidationResult.Fail(_message, _severity);

            return ValidationResult.Success();
        }

        ValidationResult IValidationRule<T>.Validate(T value)
        {
            if (value == null)
                return ValidationResult.Fail(_message);

            if (value is false)
                return ValidationResult.Fail(_message);

            return ValidationResult.Success();
        }
    }
}
