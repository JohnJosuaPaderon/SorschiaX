using System.Collections.Generic;

namespace Sorschia.Validators
{
    public class ValidationResult
    {
        public bool Status { get; set; }
        public string FailureMessage { get; set; }
        public string Target { get; set; }
        public IList<ValidationResultDataItem> Data { get; set; } = new List<ValidationResultDataItem>();
    }
}
