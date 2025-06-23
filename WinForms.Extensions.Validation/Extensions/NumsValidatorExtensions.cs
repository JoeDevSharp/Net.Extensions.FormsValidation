using JoeDevSharp.WinForms.Extensions.Validation.Rules;

namespace JoeDevSharp.WinForms.Extensions.Validation.Extensions
{
    public static class NumsValidatorExtensions
    {
        public static Validator<int> EqualTo(this Validator<int> validator, int value, string? message = null)
        {
            return validator.AddRule(new EqualRule(value, message));
        }

        public static Validator<int> GreaterThanOrEqualTo(this Validator<int> validator, int threshold, string? message = null)
        {
            return validator.AddRule(new GreaterOrEqualRule(threshold, message));
        }

        public static Validator<int> GreaterThan(this Validator<int> validator, int threshold, string? message = null)
        {
            return validator.AddRule(new GreaterThanRule(threshold, message));
        }

        public static Validator<int> LessThanOrEqualTo(this Validator<int> validator, int threshold, string? message = null)
        {
            return validator.AddRule(new LessOrEqualRule(threshold, message));
        }

        public static Validator<int> LessThan(this Validator<int> validator, int threshold, string? message = null)
        {
            return validator.AddRule(new LessThanRule(threshold, message));
        }

        public static Validator<int> NotEqualTo(this Validator<int> validator, int value, string? message = null)
        {
            return validator.AddRule(new NotEqualRule(value, message));
        }

        public static Validator<int> Range(this Validator<int> validator, int min, int max, string? message = null)
        {
            return validator.AddRule(new RangeRule(min, max, message));
        }
    }
}
