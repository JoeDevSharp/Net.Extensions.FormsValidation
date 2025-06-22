using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace JoeDevSharp.WinForms.Extensions.Validation
{
    public class FormValidator
    {
        private readonly Dictionary<string, IValidator> _fieldValidators = new();
        private List<Control> _controls = new List<Control>();

        public void AddFieldValidator<T>(Control control, Validator<T> validator)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            _fieldValidators[control.Name] = new ValidatorWrapper<T>(validator);
            _controls.Add(control);
        }

        public ValidationResult ValidateAll()
        {
            foreach (var kvp in _fieldValidators)
            {
                var controlName = kvp.Key;
                var validator = kvp.Value;

                Control control = _controls.Find(c => c.Name == controlName);
                if (control == null)
                    continue;

                var value = GetControlValue(control);
                var result = validator.Validate(value);

                if (!result.IsValid)
                    return ValidationResult.Fail($"Campo '{controlName}': {result.Message}");
            }

            return ValidationResult.Success();
        }

        private object GetControlValue(Control control)
        {
            if (control is RichTextBox rtb)
                return rtb.Text;

            if (control is TextBox tb)
                return tb.Text;

            if (control is ComboBox cb)
                return cb.DropDownStyle == ComboBoxStyle.DropDown ? (object)cb.Text : cb.SelectedItem;

            if (control is CheckBox chk)
                return chk.Checked;

            if (control is RadioButton rb)
                return rb.Checked;

            if (control is NumericUpDown nud)
                return nud.Value;

            if (control is DateTimePicker dtp)
                return dtp.Value;

            if (control is TrackBar trk)
                return trk.Value;

            if (control is ListBox lb)
                return lb.SelectedItem;

            if (control is CheckedListBox clb)
                return clb.CheckedItems;

            if (control is MaskedTextBox mtb)
                return mtb.Text;

            // Por defecto, intenta obtener la propiedad Text
            var prop = control.GetType().GetProperty("Text", BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.PropertyType == typeof(string))
                return prop.GetValue(control);

            return null;
        }

        private interface IValidator
        {
            ValidationResult Validate(object value);
        }

        private class ValidatorWrapper<T> : IValidator
        {
            private readonly Validator<T> _validator;
            public ValidatorWrapper(Validator<T> validator) => _validator = validator;

            public ValidationResult Validate(object value)
            {
                if (value == null)
                {
                    if (typeof(T).IsValueType)
                        return _validator.Validate(default);
                    return _validator.Validate((T)value);
                }

                // Intentamos castear y validar
                if (value is T val)
                    return _validator.Validate(val);

                // Si no se puede castear, devolver fallo para evitar excepciones
                return ValidationResult.Fail($"Tipo de dato inesperado para validación: esperado {typeof(T)}, recibido {value.GetType()}");
            }
        }
    }
}
