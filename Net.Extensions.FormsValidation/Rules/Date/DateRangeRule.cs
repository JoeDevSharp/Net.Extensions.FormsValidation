using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules.Date
{
    public class DateRangeRule : IValidationRule<DateTime>
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;
        private readonly string _message;
        public DateRangeRule(DateTime minDate, DateTime maxDate, string? message = null)
        {
            _minDate = minDate;
            _maxDate = maxDate;
            _message = message ?? $"Date must be between {_minDate.ToShortDateString()} and {_maxDate.ToShortDateString()}.";
        }
        public ValidationResult Validate(DateTime value)
        {
            if (value < _minDate || value > _maxDate)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
