using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface ILoginUser : IAsyncProcess<LoginUserResult>
    {
        LoginUserModel Model { get; set; }
    }

    public sealed class LoginUserModel
    {
        public string Username { get; set; }
        public string CipherPassword { get; set; }
        public int ApplicationId { get; set; }
    }

    public sealed class LoginUserResult
    {
        public Session Session { get; set; }
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
