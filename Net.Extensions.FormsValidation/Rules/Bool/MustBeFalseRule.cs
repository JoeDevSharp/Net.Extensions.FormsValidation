﻿using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class MustBeFalseRule : IValidationRule<bool>
    {
        private readonly string _message;
        public MustBeFalseRule(string? message = null)
        {
            _message = message ?? "Value must be false.";
        }
        public ValidationResult Validate(bool value)
        {
            if (value)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
