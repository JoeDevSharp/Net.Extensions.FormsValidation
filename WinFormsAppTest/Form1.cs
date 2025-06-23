using JoeDevSharp.WinForms.Extensions.Validation;
using JoeDevSharp.WinForms.Extensions.Validation.Extensions;
using JoeDevSharp.WinForms.Extensions.Validation.Rules;

namespace WinFormsAppTest
{
    public partial class Form1 : Form
    {
        private readonly FormValidator _formValidator = new();
        public Form1()
        {
            InitializeComponent();

            // Asociamos validadores a controles sin pasar getter explícito
            _formValidator.AddFieldValidator(textBox1,
                new Validator<string>()
                    .AddRule(new RequiredRule<string>("El nombre es obligatorio"))
                    .AddRule(new LengthRule(min: 3, max: 20)));

            _formValidator.AddFieldValidator(textBox1,
                new Validator<string>()
                    .NotContains("test")
                    .MaxLength(10, "El nombre no puede exceder los 10 caracteres"));

            _formValidator.AddFieldValidator(textBox2,
                new Validator<string>()
                    .AddRule(new RequiredRule<string>("El apellido es obligatorio"))
                    .AddRule(new LengthRule(min: 3, max: 20)));

            _formValidator.AddFieldValidator(textBox3,
                new Validator<string>()
                    .AddRule(new RequiredRule<string>("El email es obligatorio"))
                    .AddRule(new RegexRule(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", "Email no válido")));

            _formValidator.AddFieldValidator(checkBox1,
                new Validator<bool>()
                    .AddRule(new CustomRule<bool>(b => b == true, "Debe estar activo")));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = _formValidator.ValidateForm();

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
