using System;

namespace Sorschia
{
    public interface IDependencyProvider
    {
        object Get(Type dependencyType);
    }
}
