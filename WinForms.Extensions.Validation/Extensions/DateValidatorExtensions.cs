using JoeDevSharp.WinForms.Extensions.Validation.Rules;
using JoeDevSharp.WinForms.Extensions.Validation.Rules.Date;

namespace JoeDevSharp.WinForms.Extensions.Validation.Extensions
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
