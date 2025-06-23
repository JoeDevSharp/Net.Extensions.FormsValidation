using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class AnyMatchRule : IValidationRule<ICollection<object>>
    {
        private readonly Func<object, bool> _predicate;
        private readonly string _message;
        public AnyMatchRule(Func<object, bool> predicate, string? message = null)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _message = message ?? "No items in the collection match the specified condition.";
        }
        public ValidationResult Validate(ICollection<object> value)
        {
            if (value == null || !value.Any(_predicate))
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
