namespace Sorschia.Processes
{
    public interface IDeleteApplication : IAsyncProcess<DeleteApplicationInput, bool>
    {
    }

    public sealed class DeleteApplicationInput
    {
        public short Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
