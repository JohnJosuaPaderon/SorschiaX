using Sorschia.SystemCore.Processes;
using Sorschia.Validators;

namespace Sorschia.SystemCore.Validators
{
    public interface IApplicationValidator
    {
        AggregatedValidationResult Delete(DeleteApplicationModel model);
        AggregatedValidationResult Get(int id);
        AggregatedValidationResult Save(SaveApplicationModel model);
        AggregatedValidationResult Search(SearchApplicationModel model);
    }
}
