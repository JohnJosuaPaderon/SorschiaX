namespace Sorschia.SystemBase.Security.Processes
{
    public interface IDeleteModule : IAsyncProcess<bool>
    {
        DeleteModuleModel Model { get; set; }
    }

    public sealed class DeleteModuleModel
    {
        public int Id { get; set; }
    }
}
