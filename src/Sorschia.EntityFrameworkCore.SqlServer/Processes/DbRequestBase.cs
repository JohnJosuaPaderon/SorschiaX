using SystemBase.Data;

namespace Sorschia.Processes
{
    internal abstract class DbRequestBase<TContext> where TContext : SystemBaseDbContext
    {
        protected TContext Context { get; }

        protected DbRequestBase(TContext context)
        {
            Context = context;
        }

        public void ValidateContext()
        {
            DbContextValidator.Validate(Context);
        }

        public TContext TryGetContext()
        {
            ValidateContext();
            return Context;
        }
    }
}
