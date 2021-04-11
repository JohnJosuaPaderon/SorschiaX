using Sorschia.Data.Exceptions.Builders;

namespace Sorschia.Data
{
    public static class DbContextValidator
    {
        public static void Validate<TDbContext>(TDbContext dbContext) where TDbContext : class
        {
            if (dbContext is null)
                throw new InvalidDbContextExceptionBuilder()
                    .WithDbContextType<TDbContext>()
                    .WithMessage($"Invalid DB Context of type '${typeof(TDbContext).FullName}'")
                    .Build();
        }
    }
}
