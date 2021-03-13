namespace Sorschia.Data
{
    public class StringPropertyOptions : PropertyOptions
    {
        public int? MaxLength { get; init; }

        public StringPropertyOptions(string columnName) : base(columnName)
        {
        }
    }
}
