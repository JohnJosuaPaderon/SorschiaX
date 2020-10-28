using System.Collections.Generic;

namespace Sorschia.Validators
{
    public sealed class ValidationResultBuilder
    {
        private bool _status;
        private string _failureMessage;
        private string _target;
        private readonly IList<ValidationResultDataItem> _data = new List<ValidationResultDataItem>();

        public ValidationResultBuilder(bool status = true)
        {
            _status = status;
        }

        public ValidationResultBuilder SetStatus(bool status)
        {
            _status = status;
            return this;
        }

        public ValidationResultBuilder SetFailureMessage(string failureMessage)
        {
            _failureMessage = failureMessage;
            return this;
        }

        public ValidationResultBuilder SetTarget(string target)
        {
            _target = target;
            return this;
        }

        public ValidationResultBuilder AddDataItem(ValidationResultDataItem dataItem)
        {
            _data.Add(dataItem);
            return this;
        }

        public ValidationResult Build()
        {
            return new ValidationResult
            {
                Status = _status,
                FailureMessage = _failureMessage,
                Target = _target
            };
        }
    }
}
