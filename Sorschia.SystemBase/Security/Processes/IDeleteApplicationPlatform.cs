namespace Sorschia.SystemBase.Security.Processes
{
    public interface IDeleteApplicationPlatform : IAsyncProcess<bool>
    {
        DeleteApplicationPlatformModel Model { get; set; }
    }

    public sealed class DeleteApplicationPlatformModel
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
