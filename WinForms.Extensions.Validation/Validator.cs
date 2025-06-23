using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;
using System.Collections.Generic;

namespace JoeDevSharp.WinForms.Extensions.Validation
{
    public class Validator<T>
    {
        private readonly List<IValidationRule<T>> _rules = new List<IValidationRule<T>>();

        public Validator<T> AddRule(IValidationRule<T> rule)
        {
            _rules.Add(rule);
            return this;
        }


        public ValidationResult Validate(T value)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Validate(value);
                if (!result.IsValid)
                    return result;
            }
            return ValidationResult.Success();
        }
    }
}
