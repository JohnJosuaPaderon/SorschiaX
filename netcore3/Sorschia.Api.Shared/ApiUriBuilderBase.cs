using System;

namespace Sorschia
{
    public abstract class ApiUriBuilderBase
    {
        public string BaseUriString { get; }

        public ApiUriBuilderBase(string baseUriString)
        {
            BaseUriString = baseUriString;
        }

        public Uri Build(string relativeUriString) => new Uri($"{BaseUriString}/{relativeUriString}");
    }
}
