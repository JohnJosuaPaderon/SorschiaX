namespace Sorschia.Auditing
{
    public interface ICurrentFootprintProvider
    {
        Footprint Current { get; }
    }
}
