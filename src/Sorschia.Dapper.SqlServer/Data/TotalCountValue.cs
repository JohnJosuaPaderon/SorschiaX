namespace Sorschia.Data
{
    public class TotalCountValue<T>
    {
        public T TotalCount { get; set; }

        public static implicit operator T(TotalCountValue<T> source)
        {
            return source.TotalCount;
        }
    }

    public class TotalCountInt16 : TotalCountValue<short>
    {
    }

    public class TotalCountInt32 : TotalCountValue<int>
    {
    }

    public class TotalCountInt64 : TotalCountValue<long>
    {
    }
}
