namespace Sorschia.Audit
{
    public interface ICurrentFootprintProvider
    {
        IFootprint Current { get; }
    }
}
