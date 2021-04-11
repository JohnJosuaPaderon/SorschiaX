using MediatR;
using Sorschia.Identity.Processes.Results;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes
{
    public class InsertRole : IRequest<InsertRoleResult>
    {
        public string LookupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<PermissionObj> Permissions { get; set; }

        public class PermissionObj
        {
            public string LookupCode { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
