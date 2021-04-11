using Sorschia.Identity.Data;
using Sorschia.Processes;

namespace Sorschia.Identity.Processes
{
    internal abstract class DbRequestBase : DbRequestBase<IdentityContext>
    {
        protected DbRequestBase(IdentityContext context) : base(context)
        {
        }
    }
}
