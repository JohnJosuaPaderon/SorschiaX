using Sorschia.Entities;

namespace Sorschia.Utilities
{
    public interface IFullNameBuilder
    {
        string Generate(INameable nameable);
    }
}
