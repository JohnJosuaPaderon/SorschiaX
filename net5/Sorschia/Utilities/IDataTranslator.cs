namespace Sorschia.Utilities
{
    public interface IDataTranslator<TData1, TData2>
    {
        TData1 Translate(TData2 source);
        TData2 Translate(TData1 source);
    }
}
