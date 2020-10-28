using System.Collections.Generic;

namespace Sorschia.Validators
{
    public class AggregatedValidationResult : ValidationResult
    {
        public IList<ValidationResult> Results { set; get; } = new List<ValidationResult>();
    }
}
