# 📘 Net.Extensions.FormsValidation

### Declarative, decoupled, and UI-agnostic validation framework for .NET applications

---

## 🎯 Goal

`Net.Extensions.FormsValidation` decouples validation logic from UI components, offering a fluent, reusable, and strongly-typed way to define validation rules for any data type. It's compatible with **WinForms**, **WPF**, **Blazor**, **ASP.NET Core**, **Maui**, and any other .NET UI or data-based technology.

---

## 🧱 Architecture

| Component                   | Description                                                      |
| --------------------------- | ---------------------------------------------------------------- |
| `FormValidator`             | Main coordinator that registers fields and triggers validation.  |
| `Validator<T>`              | Core component to compose rules for type `T`.                    |
| `ValidationResult`          | Represents the result of a validation with severity and message. |
| `ValidationRule<T>`         | Individual rule implementing logic for a `Validator<T>`.         |
| Extensions (`*.Extensions`) | Extension methods providing ready-to-use rules.                  |

---

## 🧪 Usage Example

```csharp
var formValidator = new FormValidator();

var nameValidator = Validator<string>
    .Create()
    .Required("Name is required")
    .MinLength(3, "Minimum 3 characters")
    .MaxLength(50);

var ageValidator = Validator<int>
    .Create()
    .GreaterThan(17, "Must be an adult")
    .LessThanOrEqualTo(99);

formValidator.AddFieldValidator("Name", () => nameInput.Text, nameValidator);
formValidator.AddFieldValidator("Age", () => int.Parse(ageInput.Text), ageValidator);

var result = formValidator.Validate();

if (!result.IsValid)
{
    Console.WriteLine(result.Message); // Or display it in the UI
}
```

---

## 🧩 Available Extensions

### 📄 Text (`string`)

- `.Required()`
- `.MinLength(int)` / `.MaxLength(int)` / `.Length(min, max)`
- `.Email()`
- `.UrlRule()`
- `.StartsWith()`, `.EndsWith()`, `.Contains()`, `.NotContains()`
- `.Regex()`

### 🔢 Numbers (`int`, `double`, etc.)

- `.GreaterThan()`, `.GreaterThanOrEqualTo()`
- `.LessThan()`, `.LessThanOrEqualTo()`
- `.EqualTo()`, `.NotEqualTo()`
- `.Range(min, max)`

### 🕒 Dates (`DateTime`)

- `.PastDateRule()`
- `.FutureDateRule()`
- `.DateRange(min, max)`

### 🧺 Collections (`ICollection<object>`, lists, arrays)

- `.NotEmpty()`
- `.MinCount(int)` / `.MaxCount(int)`
- `.AnyMatch(predicate)` / `.AllMatch(predicate)`

---

## ✅ `ValidationResult`

Simple class representing the result of a validation:

```csharp
public class ValidationResult
{
    public bool IsValid => Severity == null;
    public ValidationSeverity? Severity { get; }
    public string Message { get; }

    public static ValidationResult Success() => new ValidationResult();
    public static ValidationResult Fail(string message, ValidationSeverity severity = ValidationSeverity.Error)
        => new ValidationResult(severity, message);
}
```

---

## 🔌 UI Integration (Examples)

### WinForms

```csharp
var validator = new FormValidator();
var emailValidator = Validator<string>
    .Create()
    .Required("Email is required")
    .Email("Invalid email");

validator.AddFieldValidator("Email", () => emailTextBox.Text, emailValidator);

var result = validator.Validate();
if (!result.IsValid)
{
    MessageBox.Show(result.Message);
}
```

### Blazor

```razor
<EditForm OnValidSubmit="Validate">
    <InputText @bind-Value="Model.Email" class="form-control" />
    <ValidationMessage For="@(() => Model.Email)" />
    <button type="submit">Validate</button>
</EditForm>

@if (!string.IsNullOrEmpty(ErrorMessage))
{
    <p class="text-danger">@ErrorMessage</p>
}

@code {
    private FormValidator validator = new();
    private string ErrorMessage = string.Empty;
    private MyModel Model = new();

    protected override void OnInitialized()
    {
        var emailValidator = Validator<string>
            .Create()
            .Required("Email is required")
            .Email("Invalid email format");

        validator.AddFieldValidator("Email", () => Model.Email, emailValidator);
    }

    void Validate()
    {
        var result = validator.Validate();
        ErrorMessage = result.IsValid ? string.Empty : result.Message;
    }

    public class MyModel
    {
        public string Email { get; set; } = string.Empty;
    }
}
```

### WPF

```csharp
var validator = new FormValidator();
var nameValidator = Validator<string>
    .Create()
    .Required("Name is required")
    .MinLength(2);

validator.AddFieldValidator("Name", () => NameTextBox.Text, nameValidator);

var result = validator.Validate();
if (!result.IsValid)
{
    MessageBox.Show(result.Message);
}
```

### ASP.NET Core (MVC)

```csharp
public class MyModel
{
    public string Email { get; set; } = string.Empty;
}

[HttpPost]
public IActionResult Submit(MyModel model)
{
    var validator = new FormValidator();
    var emailValidator = Validator<string>
        .Create()
        .Required("Email is required")
        .Email("Invalid email");

    validator.AddFieldValidator("Email", () => model.Email, emailValidator);

    var result = validator.Validate();
    if (!result.IsValid)
    {
        ModelState.AddModelError("Email", result.Message);
        return View(model);
    }

    // Proceed normally
    return RedirectToAction("Success");
}
```

---

## 🧱 Key Benefits

- ✅ Fully decoupled from the UI
- 🧪 Composable and reusable validations
- 🔄 Easy to integrate with any architecture (MVVM, MVP, etc.)
- ♻️ Reusable in services, APIs, and business logic

---

## 🚧 Roadmap

- Async validation support
- Sectioned/grouped field validation
- Error message localization
- Direct support for `IValidationAttribute`

---

## 🗂️ Main Namespaces

- `Net.Extensions.FormsValidation`
- `Net.Extensions.FormsValidation.Extensions`
- `Net.Extensions.FormsValidation.Rules`
- `Net.Extensions.FormsValidation.Enums`

---

## 📦 Installation (coming soon to NuGet)

```bash
dotnet add package JoeDevSharp.Net.Extensions.FormsValidation
```

---

> Built for developers seeking **modern, fluent, and decoupled validation** in any .NET stack.

---
