namespace Sorschia.Exceptions
{
    public struct EntityField
    {
        public string Name { get; }
        public object? Value { get; }

        public EntityField(string name, object? value)
        {
            Name = name;
            Value = value;
        }
    }
}
