namespace Sorschia.Data
{
    public class EntityOptions
    {
        public string TableName { get; }
        public string Schema { get; }
        public bool IsInsertIgnored { get; init; }
        public bool IsUpdateIgnored { get; init; }
        public bool IsDeleteIgnored { get; init; }
        public PropertyOptions IsDeleted { get; init; } = new PropertyOptions("IsDeleted");
        public PropertyOptions InsertedById { get; init; } = new PropertyOptions("InsertedById");
        public PropertyOptions InsertedOn { get; init; } = new PropertyOptions("InsertedOn");
        public PropertyOptions UpdatedById { get; init; } = new PropertyOptions("UpdatedById");
        public PropertyOptions UpdatedOn { get; init; } = new PropertyOptions("UpdatedOn");
        public PropertyOptions DeletedById { get; init; } = new PropertyOptions("DeletedById");
        public PropertyOptions DeletedOn { get; init; } = new PropertyOptions("DeletedOn");

        public EntityOptions(string tableName, string schema = null)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new SorschiaException($"argument '{nameof(tableName)}' is required and cannot be set to null or white-space");

            TableName = tableName;
            Schema = schema;
        }
    }
}
