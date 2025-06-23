using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules
{
    public class LessOrEqualRule : IValidationRule<int>
    {
        private readonly int _threshold;
        private readonly string _message;
        public LessOrEqualRule(int threshold, string? message = null)
        {
            _threshold = threshold;
            _message = message ?? $"Value must be less than or equal to {_threshold}.";
        }
        public ValidationResult Validate(int value)
        {
            if (value > _threshold)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
