using Sorschia.SystemCore.Configuration;
using Sorschia.SystemCore.Processes;
using Sorschia.Validators;

namespace Sorschia.SystemCore.Validators
{
    internal sealed class ApplicationValidator : IApplicationValidator
    {
        private readonly SystemCoreConfiguration _configuration;

        public ApplicationValidator(SystemCoreConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AggregatedValidationResult Delete(DeleteApplicationModel model) => new AggregatedValidator()
            .NotNull(model, _configuration.Validation.NotNullModel)
            .NotEqual(model.Id, _configuration.Validation.Application.InvalidId)
            .Validate();

        public AggregatedValidationResult Get(int id) => new AggregatedValidator()
            .NotEqual(id, _configuration.Validation.Application.InvalidId)
            .Validate();

        public AggregatedValidationResult Save(SaveApplicationModel model) => new AggregatedValidator()
            .NotNull(model, _configuration.Validation.NotNullModel)
            .StringMaxLength(model.Application.Name, _configuration.Validation.Application.NameMaxLength)
            .StringMinLength(model.Application.Name, _configuration.Validation.Application.NameMinLength)
            .Validate();

        public AggregatedValidationResult Search(SearchApplicationModel model) => new AggregatedValidator()
            .Validate();
    }
}
