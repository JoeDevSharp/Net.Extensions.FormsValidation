using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class AllMatchRule : IValidationRule<ICollection<object>>
    {
        private readonly Func<object, bool> _predicate;
        private readonly string _message;
        public AllMatchRule(Func<object, bool> predicate, string? message = null)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _message = message ?? "Not all items in the collection match the specified condition.";
        }
        public ValidationResult Validate(ICollection<object> value)
        {
            if (value == null || !value.All(_predicate))
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
