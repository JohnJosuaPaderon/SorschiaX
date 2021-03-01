namespace Sorschia.Processes
{
    public interface IGetApplication : IAsyncProcess<short, GetApplicationOutput>
    {
    }

    public sealed class GetApplicationOutput
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}
