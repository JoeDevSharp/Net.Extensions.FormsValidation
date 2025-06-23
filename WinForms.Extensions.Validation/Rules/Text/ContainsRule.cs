using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class ContainsRule : IValidationRule<string>
    {
        private readonly string _substring;
        private readonly string _message;
        public ContainsRule(string substring, string? message = null)
        {
            _substring = substring;
            _message = message ?? $"Value must contain '{_substring}'.";
        }
        public ValidationResult Validate(string value)
        {
            if (value == null) value = string.Empty;
            if (!value.Contains(_substring))
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
