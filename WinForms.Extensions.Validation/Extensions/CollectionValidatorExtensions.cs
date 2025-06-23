using JoeDevSharp.WinForms.Extensions.Validation.Rules;

namespace JoeDevSharp.WinForms.Extensions.Validation.Extensions
{
    public static class CollectionValidatorExtensions
    {

        public static Validator<ICollection<object>> AllMatch(this Validator<ICollection<object>> validator, Func<object, bool> predicate, string? message = null)
        {
            return validator.AddRule(new AllMatchRule(predicate, message));
        }

        public static Validator<ICollection<object>> AnyMatch(this Validator<ICollection<object>> validator, Func<object, bool> predicate, string? message = null)
        {
            return validator.AddRule(new AnyMatchRule(predicate, message));
        }
        
        public static Validator<ICollection<object>> MaxCount(this Validator<ICollection<object>> validator, int maxCount, string? message = null)
        {
            return validator.AddRule(new MaxCountRule(maxCount, message));
        }

        public static Validator<ICollection<object>> MinCount(this Validator<ICollection<object>> validator, int minCount, string? message = null)
        {
            return validator.AddRule(new MinCountRule(minCount, message));
        }

        public static Validator<ICollection<object>> NotEmpty(this Validator<ICollection<object>> validator, string? message = null)
        {
            return validator.AddRule(new NotEmptyCollectionRule(message));
        }
    }
}
