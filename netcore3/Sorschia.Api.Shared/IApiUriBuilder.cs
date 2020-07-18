using System;

namespace Sorschia
{
    public interface IApiUriBuilder
    {
        string BaseUriString { get; }
        Uri Build(string relativeUriString);
    }
}
