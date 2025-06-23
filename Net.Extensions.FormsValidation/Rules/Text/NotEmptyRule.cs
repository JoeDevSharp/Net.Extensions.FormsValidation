using System.Collections;
using Net.Extensions.FormsValidation.Interfaces;

namespace Net.Extensions.FormsValidation.Rules.Common
{
    /// <summary>
    /// Valida que una colección o cadena no esté vacía.
    /// </summary>
    public sealed class NotEmptyRule<T> : IValidationRule<T>
    {
        private readonly string _message;

        public NotEmptyRule(string? message = null)
        {
            _message = message ?? "La colección no debe estar vacía.";
        }

        public ValidationResult Validate(T value)
        {
            if (value == null)
                return ValidationResult.Fail(_message);

            // Caso string
            if (value is string str)
            {
                return string.IsNullOrWhiteSpace(str) ? ValidationResult.Fail(_message) : ValidationResult.Success();
            }

            // Caso ICollection (incluye IList, IDictionary, arrays implementan ICollection)
            if (value is ICollection collection)
            {
                return collection.Count > 0 ? ValidationResult.Success() : ValidationResult.Fail(_message);
            }

            // Caso IEnumerable que no sea ICollection (iterar para verificar si tiene al menos un elemento)
            if (value is IEnumerable enumerable)
            {
                foreach (var _ in enumerable)
                    return ValidationResult.Success();
                return ValidationResult.Fail(_message);
            }

            return ValidationResult.Fail("Tipo no válido: no es una colección enumerable o cadena.");
        }
    }
}
