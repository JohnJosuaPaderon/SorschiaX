using Microsoft.AspNetCore.Authorization;

namespace Sorschia.Authorization
{
    public class RequestHeaderRequirement : IAuthorizationRequirement
    {
        public string HeaderName { get; }

        public RequestHeaderRequirement(string headerName)
        {
            if (string.IsNullOrWhiteSpace(headerName))
                throw new SorschiaException("Header name is null or white-space");

            HeaderName = headerName;
        }
    }
}
