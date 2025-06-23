using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class NotEqualRule : IValidationRule<int>
    {
        private readonly int _value;
        private readonly string _message;
        public NotEqualRule(int value, string? message = null)
        {
            _value = value;
            _message = message ?? $"Value must not be equal to {_value}.";
        }
        public ValidationResult Validate(int value)
        {
            if (value == _value)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
