using System.Collections.Generic;

namespace Sorschia.Validators
{
    public class AggregatedValidator : IAggregatedValidator
    {
        private readonly IList<IValidator> _validators = new List<IValidator>();
        public bool IsFailFast { get; }

        public AggregatedValidator(bool isFailFast = true)
        {
            IsFailFast = isFailFast;
        }

        public IAggregatedValidator Add(IValidator validator)
        {
            _validators.Add(validator);
            return this;
        }

        public AggregatedValidationResult Validate()
        {
            var resultBuilder = new AggregatedValidationResultBuilder();

            foreach (var validator in _validators)
            {
                var result = validator.Validate();
                resultBuilder.AddResult(result);

                if (!result.Status)
                {
                    resultBuilder.SetStatus(result.Status);

                    if (IsFailFast)
                        return resultBuilder
                            .SetStatus(result.Status)
                            .SetFailureMessage(result.FailureMessage)
                            .SetTarget(result.Target)
                            .Build();
                }
            }

            return resultBuilder.Build();
        }
    }
}
