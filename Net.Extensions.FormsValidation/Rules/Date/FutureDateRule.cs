using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class FutureDateRule : IValidationRule<DateTime>
    {
        private readonly string _message;
        public FutureDateRule(string? message = null)
        {
            _message = message ?? "Date must be in the future.";
        }
        public ValidationResult Validate(DateTime value)
        {
            if (value <= DateTime.Now)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
