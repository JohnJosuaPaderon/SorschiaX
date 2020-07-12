using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IValidateUserModule : IAsyncProcess<bool>
    {
        ValidateUserModuleModel Model { get; set; }
    }

    public sealed class ValidateUserModuleModel
    {
        public int UserId { get; set; }
        public int ModuleId { get; set; }
    }
}
