using Refit;
using System.Net.Http;

namespace Sorschia.ApiServices
{
    internal sealed class ApiServiceProvider
    {
        private readonly IApiUriBuilder _uriBuilder;
        private readonly IUrlParameterFormatter _parameterFormatter;
        private readonly AuthenticatedHttpClientHandler _httpClientHandler;

        public ApiServiceProvider(IApiUriBuilder uriBuilder, IUrlParameterFormatter parameterFormatter, AuthenticatedHttpClientHandler httpClientHandler)
        {
            _uriBuilder = uriBuilder;
            _parameterFormatter = parameterFormatter;
            _httpClientHandler = httpClientHandler;
        }

        public T GetApiService<T>(string relativeUriString)
        {
            var httpClient = new HttpClient(_httpClientHandler)
            {
                BaseAddress = _uriBuilder.Build(relativeUriString)
            };

            var settings = new RefitSettings
            {
                UrlParameterFormatter = _parameterFormatter
            };

            return RestService.For<T>(httpClient, settings);
        }
    }
}
