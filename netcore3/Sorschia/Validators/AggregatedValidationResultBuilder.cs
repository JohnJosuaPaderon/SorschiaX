using System.Collections.Generic;

namespace Sorschia.Validators
{
    public sealed class AggregatedValidationResultBuilder
    {
        private bool _status;
        private string _failureMessage;
        private string _target;
        private readonly IList<ValidationResultDataItem> _data = new List<ValidationResultDataItem>();
        private readonly IList<ValidationResult> _results = new List<ValidationResult>();

        public AggregatedValidationResultBuilder(bool status = true)
        {
            _status = status;
        }

        public AggregatedValidationResultBuilder SetStatus(bool status)
        {
            _status = status;
            return this;
        }

        public AggregatedValidationResultBuilder SetFailureMessage(string failureMessage)
        {
            _failureMessage = failureMessage;
            return this;
        }

        public AggregatedValidationResultBuilder SetTarget(string target)
        {
            _target = target;
            return this;
        }

        public AggregatedValidationResultBuilder AddDataItem(ValidationResultDataItem dataItem)
        {
            _data.Add(dataItem);
            return this;
        }

        public AggregatedValidationResultBuilder AddResult(ValidationResult result)
        {
            _results.Add(result);
            return this;
        }

        public AggregatedValidationResult Build()
        {
            return new AggregatedValidationResult
            {
                Status = _status,
                FailureMessage = _failureMessage,
                Target = _target,
                Data = _data,
                Results = _results
            };
        }
    }
}
