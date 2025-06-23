using Net.Extensions.FormsValidation.Interfaces;
using System.Text.RegularExpressions;

namespace Net.Extensions.FormsValidation.Rules
{
    public class RegexRule : IValidationRule<string>
    {
        private readonly Regex _regex;
        private readonly string _message;

        public RegexRule(string pattern, string? message = null)
        {
            _regex = new Regex(pattern);
            _message = message ?? "The format is not valid";
        }

        public ValidationResult Validate(string value)
        {
            if (value == null) value = string.Empty;

            if (!_regex.IsMatch(value))
                return ValidationResult.Fail(_message);

            return ValidationResult.Success();
        }
    }
}
