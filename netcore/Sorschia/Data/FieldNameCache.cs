using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Sorschia.Data
{
    internal sealed class FieldNameCache : IFieldNameCache
    {
        private readonly IDictionary<string, int> _source = new Dictionary<string, int>();

        public bool TryGet(DbDataReader reader, string fieldName, out object result)
        {
            result = default;

            ValidateReader(reader);
            ValidateFieldName(fieldName);
            fieldName = CleanFieldName(fieldName);

            if (_source.ContainsKey(fieldName))
            {
                var ordinal = _source[fieldName];

                if (ordinal >= 0)
                {
                    result = reader.GetValue(ordinal);
                    return true;
                }

                return false;
            }

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(reader.GetName(i), fieldName, StringComparison.CurrentCultureIgnoreCase))
                {
                    _source.Add(fieldName, i);
                    result = reader.GetValue(i);
                    return true;
                }
            }

            _source.Add(fieldName, -1);
            return false;
        }

        private void ValidateReader(DbDataReader reader)
        {
            if (reader is null || reader.FieldCount == 0)
                throw new SorschiaException("reader is either null or has no fields");
        }

        private void ValidateFieldName(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new SorschiaException("fieldName is set to null or white-space");
        }

        private string CleanFieldName(string fieldName) => fieldName.Trim('[', ']');
    }
}
