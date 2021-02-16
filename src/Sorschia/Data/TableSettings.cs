namespace Sorschia.Data
{
    public class TableSettings
    {
        public string TableName { get; set; }
        public bool? IsInsertFootprintIgnored { get; set; }
        public bool? IsUpdateFootprintIgnored { get; set; }
        public bool? IsDeleteFootprintIgnored { get; set; }
    }

    public class EntityTableSettings : TableSettings
    {
        public ColumnSettings Id { get; set; } = new ColumnSettings
        {
            ColumnName = "Id"
        };
    }
}
