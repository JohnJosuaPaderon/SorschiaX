namespace Sorschia.Data
{
    partial class DataOptions
    {
        public sealed class Application_OptionsObj : EntityOptions
        {
            public PropertyOptions Id { get; init; } = new PropertyOptions("Id");
            public StringPropertyOptions Name { get; init; } = new StringPropertyOptions("Name")
            {
                IsRequired = true,
                MaxLength = 50
            };
            public StringPropertyOptions Description { get; init; } = new StringPropertyOptions("Description")
            {
                MaxLength = 200
            };

            public Application_OptionsObj(string tableName, string schema = null) : base(tableName, schema)
            {
            }
        }
    }
}
