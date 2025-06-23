namespace Net.Extensions.FormsValidation.Interfaces
{
    public interface IValidationRule<T>
    {
        ValidationResult Validate(T value);
    }
}
