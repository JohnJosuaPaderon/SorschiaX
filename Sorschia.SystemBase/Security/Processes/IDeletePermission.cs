namespace Sorschia.SystemBase.Security.Processes
{
    public interface IDeletePermission : IAsyncProcess<bool>
    {
        DeletePermissionModel Model { get; set; }
    }

    public sealed class DeletePermissionModel
    {
        public int Id { get; set; }
    }
}
