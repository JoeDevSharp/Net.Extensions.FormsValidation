﻿using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules
{
    public class PastDateRule : IValidationRule<DateTime>
    {
        private readonly string _message;
        public PastDateRule(string? message = null)
        {
            _message = message ?? "Date must be in the past.";
        }
        public ValidationResult Validate(DateTime value)
        {
            if (value >= DateTime.Now)
                return ValidationResult.Fail(_message);
            return ValidationResult.Success();
        }
    }
}
