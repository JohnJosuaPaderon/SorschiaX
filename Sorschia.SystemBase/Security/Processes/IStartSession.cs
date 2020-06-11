using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IStartSession : IAsyncProcess<StartSessionResult>
    {
        StartSessionModel Model { get; set; }
    }

    public sealed class StartSessionModel
    {
        public int? UserId { get; set; }
        public int? ApplicationId { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string OperatingSystem { get; set; }
    }

    public sealed class StartSessionResult
    {
        public SystemSession Session { get; set; }
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
