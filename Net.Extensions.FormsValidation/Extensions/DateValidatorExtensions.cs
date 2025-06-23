using Net.Extensions.FormsValidation.Rules;
using Net.Extensions.FormsValidation.Rules.Date;

namespace Net.Extensions.FormsValidation.Extensions
{
    public static class DateValidatorExtensions
    {

        public static Validator<DateTime> DateRange(this Validator<DateTime> validator, DateTime minDate, DateTime maxDate, string? message = null)
        {
            return validator.AddRule(new DateRangeRule(minDate, maxDate, message));
        }

        public static Validator<DateTime> FutureDateRule(this Validator<DateTime> validator, string? message = null)
        {
            return validator.AddRule(new FutureDateRule(message));
        }

        public static Validator<DateTime> PastDateRule(this Validator<DateTime> validator, string? message = null)
        {
            return validator.AddRule(new PastDateRule(message));
        }
    }
}
