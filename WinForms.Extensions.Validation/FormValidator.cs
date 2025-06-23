namespace JoeDevSharp.WinForms.Extensions.Validation
{
    public sealed class FormValidator
    {
        private readonly Dictionary<string, FieldEntry> _fields = new();

        /// <summary>
        /// Registra un validador con clave y un getter del valor.
        /// </summary>
        public void AddFieldValidator<T>(string key, Func<object?> valueGetter, Validator<T> validator)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("La clave no puede estar vacía", nameof(key));
            if (valueGetter == null)
                throw new ArgumentNullException(nameof(valueGetter));
            if (validator == null)
                throw new ArgumentNullException(nameof(validator));

            _fields[key] = new FieldEntry(new ValidatorWrapper<T>(validator), valueGetter);
        }

        /// <summary>
        /// Valida todos los campos y devuelve el primer error encontrado.
        /// </summary>
        public ValidationResult Validate()
        {
            foreach (var (key, entry) in _fields)
            {
                object? value = entry.ValueGetter();
                var result = entry.Validator.Validate(value);
                if (!result.IsValid)
                    return ValidationResult.Fail($"Campo '{key}': {result.Message}");
            }
            return ValidationResult.Success();
        }

        // --- Internos ---

        private readonly record struct FieldEntry(IValidator Validator, Func<object?> ValueGetter);

        private interface IValidator
        {
            ValidationResult Validate(object? value);
        }

        private sealed class ValidatorWrapper<T> : IValidator
        {
            private readonly Validator<T> _validator;
            public ValidatorWrapper(Validator<T> validator) => _validator = validator;

            public ValidationResult Validate(object? value)
            {
                if (value == null)
                {
                    if (typeof(T).IsValueType && Nullable.GetUnderlyingType(typeof(T)) == null)
                        return _validator.Validate(default!);
                    return _validator.Validate((T?)value);
                }

                if (value is T val)
                    return _validator.Validate(val);

                try
                {
                    var converted = (T)Convert.ChangeType(value, typeof(T));
                    return _validator.Validate(converted);
                }
                catch
                {
                    return ValidationResult.Fail($"Tipo inválido: se esperaba '{typeof(T).Name}', recibido '{value.GetType().Name}'.");
                }
            }
        }
    }
}
