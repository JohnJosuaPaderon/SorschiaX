namespace Sorschia.Processes
{
    public interface IInsertApplication : IAsyncProcess<InsertApplicationInput, InsertApplicationOutput>
    {
    }

    public sealed class InsertApplicationInput
    {
        public string Name { get; set; }
    }

    public sealed class InsertApplicationOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
