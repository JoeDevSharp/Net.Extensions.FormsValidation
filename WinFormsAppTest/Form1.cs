using JoeDevSharp.WinForms.Extensions.Validation;
using JoeDevSharp.WinForms.Extensions.Validation.Extensions;

namespace WinFormsAppTest
{
    public partial class Form1 : Form
    {
        private readonly FormValidator _formValidator = new();
        public Form1()
        {
            InitializeComponent();

            // Asociamos validadores a controles sin pasar getter explícito

            _formValidator.AddFieldValidator(
                "Name",
                () => textBox1.Text,
                new Validator<string>()
                    .NotContains("test")
                    .MaxLength(10, "El nombre no puede exceder los 10 caracteres"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = _formValidator.Validate();

            if (!result.IsValid)
            {
                MessageBox.Show(result.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // gestion of error, focus on the first invalid control

                return;
            }

            MessageBox.Show("Datos validados correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
