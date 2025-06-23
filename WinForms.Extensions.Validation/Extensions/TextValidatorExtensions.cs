using JoeDevSharp.WinForms.Extensions.Validation.Rules;
using JoeDevSharp.WinForms.Extensions.Validation.Rules.Common;
using JoeDevSharp.WinForms.Extensions.Validation.Rules.Text;

namespace JoeDevSharp.WinForms.Extensions.Validation.Extensions
{
    public static class TextValidatorExtensions
    {
        public static Validator<string> Contains(this Validator<string> validator, string substring, string? message = null)
        {
            return validator.AddRule(new ContainsRule(substring, message));
        }

        public static Validator<string> Email(this Validator<string> validator, string? message = null)
        {
            return validator.AddRule(new EmailRule(message));
        }

        public static Validator<string> EndsWith(this Validator<string> validation, string suffix, string? message = null)
        {
            return validation.AddRule(new EndsWithRule(suffix, message));
        }

        public static Validator<string> Length(this Validator<string> validation, int? min = null, int? max = null, string? message = null)
        {
            return validation.AddRule(new LengthRule(min, max, message));
        }

        public static Validator<string> MaxLength(this Validator<string> validation, int max, string? message = null)
        {
            return validation.AddRule(new MaxLengthRule(max, message));
        }
        public static Validator<string> MinLength(this Validator<string> validation, int min, string? message = null)
        {
            return validation.AddRule(new MinLengthRule(min, message));
        }

        public static Validator<string> StartsWith(this Validator<string> validation, string prefix, string? message = null)
        {
            return validation.AddRule(new StartsWithRule(prefix, message));
        }

        public static Validator<string> NotContains(this Validator<string> validation, string substring, string? message = null)
        {
            return validation.AddRule(new NotContainsRule(substring, message));
        }
        public static Validator<string> Regex(this Validator<string> validation, string pattern, string? message = null)
        {
            return validation.AddRule(new RegexRule(pattern, message));
        }

        public static Validator<T> Required<T>(this Validator<T> validation, string? message = null)
        {
            return validation.AddRule(new RequiredRule<T>(message));
        }

        public static Validator<string> StartsWithRule(this Validator<string> validation, string prefix, string? message = null)
        {
            return validation.AddRule(new StartsWithRule(prefix, message));
        }

        public static Validator<T> Telephone<T>(this Validator<T> validation, string? message = null, string? patternOverride = null)
        {
            return validation.AddRule(new TelephoneRule<T>(message, patternOverride));
        }

        public static Validator<string> UrlRule(this Validator<string> v,
                                        string? message = null,
                                        IEnumerable<string>? allowedSchemes = null,
                                        bool requireHttps = false,
                                        int maxLength = 2048)
        {
            return v.AddRule(new UrlRule(message, allowedSchemes, requireHttps, maxLength));
        }

        public static Validator<T> NotEmpty<T>(this Validator<T> validation, string? message = null)
        {
            return validation.AddRule(new NotEmptyRule<T>(message));
        }
    }
}
