namespace JoeDevSharp.WinForms.Extensions.Validation.Interfaces
{
    public interface IValidationRule<T>
    {
        ValidationResult Validate(T value);
    }
}
