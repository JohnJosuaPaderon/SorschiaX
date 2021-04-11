using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes.Results
{
    public static class InsertRoleResultExtensions
    {
        public static InsertRoleResult Set(this InsertRoleResult instance, Role role)
        {
            if (instance is not null && role is not null)
            {
                instance.Id = role.Id;
                instance.LookupCode = role.LookupCode;
                instance.Name = role.Name;
                instance.Description = role.Description;
            }

            return instance;
        }
    }
}
