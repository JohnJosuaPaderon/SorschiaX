namespace Sorschia.Data
{
    public class PropertyOptions
    {
        public string ColumnName { get; }
        public bool? IsRequired { get; init; }

        public PropertyOptions(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                throw new SorschiaException($"argument '{nameof(columnName)}' is required and cannot be set to null or white-space");

            ColumnName = columnName;
        }
    }
}
