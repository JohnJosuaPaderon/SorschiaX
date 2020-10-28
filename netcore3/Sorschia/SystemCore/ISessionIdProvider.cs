namespace Sorschia.SystemCore
{
    public interface ISessionIdProvider
    {
        void SetCurrent(long sessionId);
        long? GetCurrent();
    }
}
