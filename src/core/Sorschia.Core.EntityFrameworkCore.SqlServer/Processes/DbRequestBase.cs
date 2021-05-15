using Sorschia.Core.Data;

namespace Sorschia.Core.Processes
{
    internal abstract class DbRequestBase
    {
        public CoreContext DbContext { get; }

        protected DbRequestBase(CoreContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
