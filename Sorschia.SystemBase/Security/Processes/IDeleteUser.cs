namespace Sorschia.SystemBase.Security.Processes
{
    public interface IDeleteUser : IAsyncProcess<bool>
    {
        DeleteUserModel Model { get; set; }
    }

    public sealed class DeleteUserModel
    {
        public int Id { get; set; }
    }
}
