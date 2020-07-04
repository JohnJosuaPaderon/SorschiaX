namespace Sorschia.SystemCore.Entities
{
    public class ApiPermission : Permission
    {
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
