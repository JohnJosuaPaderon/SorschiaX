using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IValidateUserApplication : IAsyncProcess<bool>
    {
        ValidateUserApplicationModel Model { get; set; }
    }

    public sealed class ValidateUserApplicationModel
    {
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
    }
}
