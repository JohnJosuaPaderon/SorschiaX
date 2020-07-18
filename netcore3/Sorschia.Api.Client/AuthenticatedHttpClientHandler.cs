using Sorschia.SystemCore;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia
{
    internal sealed class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly IAccessTokenStorage _tokenStorage;

        public AuthenticatedHttpClientHandler(IAccessTokenStorage tokenStorage)
        {
            _tokenStorage = tokenStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorization = request.Headers.Authorization;

            if (authorization != null)
                request.Headers.Authorization = new AuthenticationHeaderValue(authorization.Scheme, _tokenStorage.AccessToken?.TokenString);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
