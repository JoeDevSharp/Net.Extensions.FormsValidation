using System.Text.RegularExpressions;
using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules.Text
{
    public class TelephoneRule<T> : IValidationRule<T>
    {
        private readonly string _message;
        private readonly Regex _regex;

        // Regex por defecto: formato E.164, ejemplo: +34123456789
        private const string DefaultPattern = @"^\+?[1-9]\d{1,14}$";

        public TelephoneRule(string? message = null, string? patternOverride = null)
        {
            _message = message ?? "Formato de número de teléfono inválido.";
            _regex = new Regex(patternOverride ?? DefaultPattern, RegexOptions.Compiled);
        }

        public ValidationResult Validate(T value)
        {
            if (value is not string s)
                return ValidationResult.Fail("El valor no es un texto válido para validar como teléfono.");

            if (string.IsNullOrWhiteSpace(s) || !_regex.IsMatch(s))
                return ValidationResult.Fail(_message);

            return ValidationResult.Success();
        }
    }
}
