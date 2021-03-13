namespace Sorschia.Data
{
    partial class DataOptions
    {
        public sealed class Permission_OptionsObj : EntityOptions
        {
            public PropertyOptions Id { get; init; } = new PropertyOptions("Id");
            public StringPropertyOptions Name { get; init; } = new StringPropertyOptions("Name")
            {
                IsRequired = true,
                MaxLength = 100
            };
            public StringPropertyOptions Description { get; init; } = new StringPropertyOptions("Description")
            {
                MaxLength = 500
            };
            public StringPropertyOptions LookupKey { get; init; } = new StringPropertyOptions("LookupKey")
            {
                MaxLength = 100
            };
            public PropertyOptions ApplicationId { get; init; } = new PropertyOptions("ApplicationId");
            public PropertyOptions RoleId { get; init; } = new PropertyOptions("RoleId");

            public Permission_OptionsObj(string tableName, string schema = null) : base(tableName, schema)
            {
            }
        }
    }
}
