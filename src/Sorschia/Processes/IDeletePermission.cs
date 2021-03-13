namespace Sorschia.Processes
{
    public interface IDeletePermission : IAsyncProcess<DeletePermissionInput, bool>
    {
    }

    public sealed class DeletePermissionInput
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
