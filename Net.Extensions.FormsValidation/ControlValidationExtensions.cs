using System;
using System.Windows.Forms;

namespace Net.Extensions.FormsValidation
{
    public static class ControlValidationExtensions
    {
        public static void SetValidation<T>(
            this Control control,
            Validator<T> validator,
            Func<T> getValue,
            Action<ValidationResult> onValidationResult)
        {
            void Validate()
            {
                var result = validator.Validate(getValue());
                onValidationResult(result);
            }

            // Suscribirse a eventos típicos según control
            if (control is TextBox tb)
            {
                tb.TextChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is ComboBox cb)
            {
                cb.SelectedIndexChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is CheckBox chk)
            {
                chk.CheckedChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is DateTimePicker dtp)
            {
                dtp.ValueChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is NumericUpDown nud)
            {
                nud.ValueChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is ListBox lb)
            {
                lb.SelectedIndexChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is RadioButton rb)
            {
                rb.CheckedChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is ListView lv)
            {
                lv.SelectedIndexChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is TreeView tv)
            {
                tv.AfterSelect += (s, e) => Validate();
                Validate();
            }
            else if (control is TrackBar trb)
            {
                trb.ValueChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is DomainUpDown dud)
            {
                dud.SelectedItemChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is RichTextBox rtb)
            {
                rtb.TextChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is MaskedTextBox mtb)
            {
                mtb.TextChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is TabControl tc)
            {
                tc.SelectedIndexChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is CheckedListBox clb)
            {
                clb.SelectedIndexChanged += (s, e) => Validate();
                clb.ItemCheck += (s, e) => Validate();
                Validate();
            }
            else if (control is ScrollBar sb)
            {
                sb.ValueChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is HScrollBar hsb)
            {
                hsb.ValueChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is VScrollBar vsb)
            {
                vsb.ValueChanged += (s, e) => Validate();
                Validate();
            }
            else if (control is LinkLabel ll)
            {
                ll.LinkClicked += (s, e) => Validate();
                Validate();
            }
            else if (control is PictureBox pb)
            {
                pb.Click += (s, e) => Validate();
                Validate();
            }
            else if (control is Button btn)
            {
                btn.Click += (s, e) => Validate();
                Validate();
            }
            else if (control is NumericUpDown nudu)
            {
                nudu.ValueChanged += (s, e) => Validate();
                Validate();
            }
            else
            {
                // Validar bajo demanda o con otro evento
                Validate();
            }
        }
    }
}
