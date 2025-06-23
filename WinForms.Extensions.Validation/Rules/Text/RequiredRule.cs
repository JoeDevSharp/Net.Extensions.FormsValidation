using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class RequiredRule<T> : IValidationRule<T>
    {
        private readonly string _message;

        public RequiredRule(string message)
        {
            _message = message;
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
