using Sorschia.Validators;

namespace Sorschia.SystemCore.Configuration
{
    partial class SystemCoreConfiguration
    {
        public sealed partial class ValidationSection
        {
            public ApplicationSection Application { get; set; } = new ApplicationSection();
            public ValidatorConfiguration NotNullModel { get; set; } = new ValidatorConfiguration
            {
                FailureMessage = "Invalid model",
                Target = "model"
            };
        }
    }
}
