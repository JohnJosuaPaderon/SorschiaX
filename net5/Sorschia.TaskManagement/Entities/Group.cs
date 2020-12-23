using Sorschia.Entities;

namespace Sorschia.TaskManagement.Entities
{
    public class Group : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
