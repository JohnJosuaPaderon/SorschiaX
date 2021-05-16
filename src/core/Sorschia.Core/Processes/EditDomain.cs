using Sorschia.Core.Entities;

namespace Sorschia.Core.Processes
{
    public static class EditDomain
    {
        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        public class Response : DomainBase
        {
        }
    }
}
