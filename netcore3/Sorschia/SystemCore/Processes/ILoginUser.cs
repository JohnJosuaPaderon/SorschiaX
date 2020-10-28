using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ILoginUser : IAsyncProcess<LoginUserResult>
    {
        LoginUserModel Model { get; set; }
    }

    public sealed class LoginUserModel
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string CipherPassword { get; set; }
        public int ApplicationId { get; set; }
    }

    public sealed class LoginUserResult
    {
        public Session Session { get; set; }
        public User User { get; set; }
        public Application Application { get; set; }
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public IList<Module> Modules { get; set; }
        public IList<Permission> Permissions { get; set; }
        public IList<Session> OtherSessions { get; set; }
    }
}
