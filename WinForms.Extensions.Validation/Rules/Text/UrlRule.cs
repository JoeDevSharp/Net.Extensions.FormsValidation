using System;
using System.Collections.Generic;
using JoeDevSharp.WinForms.Extensions.Validation.Interfaces;

namespace JoeDevSharp.WinForms.Extensions.Validation.Rules.Text
{
    /// <summary>
    /// Valida que una cadena sea una URL absoluta válida.
    /// Opcionalmente permite limitar los esquemas y exigir HTTPS.
    /// </summary>
    public sealed class UrlRule : IValidationRule<string>
    {
        private readonly string _message;
        private readonly HashSet<string> _allowedSchemes;
        private readonly bool _requireHttps;
        private readonly int _maxLength;

        /// <param name="message">Mensaje de error que se mostrará cuando la URL no sea válida.</param>
        /// <param name="allowedSchemes">Lista de esquemas aceptados (http, https, ftp, etc.).  
        /// Si es null → se aceptan http y https.</param>
        /// <param name="requireHttps">Si es true solo se aceptará https.</param>
        /// <param name="maxLength">Longitud máxima permitida; evita URLs malformadas extremadamente largas.</param>
        public UrlRule(
            string? message = null,
            IEnumerable<string>? allowedSchemes = null,
            bool requireHttps = false,
            int maxLength = 2048)
        {
            _message = message ?? "El formato de la URL es inválido.";
            _requireHttps = requireHttps;
            _maxLength = maxLength > 0 ? maxLength : 2048;

            // Normaliza los esquemas a minúsculas
            _allowedSchemes = new HashSet<string>(
                allowedSchemes ?? new[] { Uri.UriSchemeHttp, Uri.UriSchemeHttps },
                StringComparer.OrdinalIgnoreCase);
        }

        public ValidationResult Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > _maxLength)
                return ValidationResult.Fail(_message);

            if (!Uri.TryCreate(value, UriKind.Absolute, out var uri))
                return ValidationResult.Fail(_message);

            // Esquema HTTPS obligatorio si se indica
            if (_requireHttps && !uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
                return ValidationResult.Fail("Solo se permite HTTPS.");

            // Validar contra la lista de esquemas permitidos
            if (!_allowedSchemes.Contains(uri.Scheme))
                return ValidationResult.Fail($"Esquema no permitido: {uri.Scheme}.");

            // Debe tener host (evita cosas como "mailto:")
            if (string.IsNullOrWhiteSpace(uri.Host))
                return ValidationResult.Fail(_message);

            return ValidationResult.Success();
        }
    }
}
