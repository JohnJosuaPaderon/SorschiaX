using Sorschia.Validators;

namespace Sorschia.SystemCore.Configuration
{
    partial class SystemCoreConfiguration
    {
        partial class ValidationSection
        {
            public sealed class ApplicationSection
            {
                public NotEqualValidator<int>.Configuration InvalidId { get; set; } = new NotEqualValidator<int>.Configuration
                {
                    ComparisonValue = 0,
                    Target = nameof(Entities.Application.Id),
                    FailureMessage = "Invalid application id"
                };

                public StringMaxLengthValidator.Configuration NameMaxLength { get; set; } = new StringMaxLengthValidator.Configuration
                {
                    MaxLength = 100,
                    Target = nameof(Entities.Application.Name),
                    FailureMessage = "Application name should not be longer than 100 characters"
                };

                public StringMinLengthValidator.Configuration NameMinLength { get; set; } = new StringMinLengthValidator.Configuration
                {
                    MinLength = 10,
                    Target = nameof(Entities.Application.Name),
                    FailureMessage = "Application name should not be shorter than 10 characters"
                };
            }
        }
    }
}
