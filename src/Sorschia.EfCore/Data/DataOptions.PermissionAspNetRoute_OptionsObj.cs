using Microsoft.VisualBasic;

namespace Sorschia.Data
{
    partial class DataOptions
    {
        public sealed class PermissionAspNetRoute_OptionsObj : EntityOptions
        {
            public PropertyOptions Id { get; init; } = new PropertyOptions("Id");
            public StringPropertyOptions AspNetArea { get; init; } = new StringPropertyOptions("AspNetArea")
            {
                MaxLength = 250
            };
            public StringPropertyOptions AspNetController { get; init; } = new StringPropertyOptions("AspNetController")
            {
                IsRequired = true,
                MaxLength = 250
            };
            public StringPropertyOptions AspNetAction { get; init; } = new StringPropertyOptions("AspNetAction")
            {
                IsRequired = true,
                MaxLength = 250
            };
            public PropertyOptions PermissionId { get; init; } = new PropertyOptions("PermissionId");

            public PermissionAspNetRoute_OptionsObj(string tableName, string schema = null) : base(tableName, schema)
            {
            }
        }
    }
}
