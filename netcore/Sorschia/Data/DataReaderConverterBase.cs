using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Data
{
    public abstract class DataReaderConverterBase<TDataReader, TResult>
    {
        public IList<string> SubObjects { get; set; }

        public abstract TResult Convert(TDataReader reader);

        protected bool IsSubObjectIncluded(string subObject) => SubObjects != null && SubObjects.Any() && SubObjects.Contains(subObject);
    }
}
