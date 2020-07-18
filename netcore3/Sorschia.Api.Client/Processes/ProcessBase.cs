using Refit;
using Sorschia.SystemCore;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes
{
    public abstract class ProcessBase<TApiService> 
    {
        private readonly IAccessTokenRefresher _tokenRefresher;
        protected readonly TApiService _apiService;

        private bool IsAccessTokenRefreshed = false;
        private bool IsAccessTokenRefreshRequired = false;

        public virtual void Dispose()
        {
        }

        public ProcessBase(IAccessTokenRefresher tokenRefresher, TApiService apiService)
        {
            _tokenRefresher = tokenRefresher;
            _apiService = apiService;
        }

        protected async Task<T> ExecuteAsync<T>(Func<Task<T>> executeAsync, CancellationToken cancellationToken = default)
        {
            try
            {
                if (IsAccessTokenRefreshRequired)
                {
                    await _tokenRefresher.RefreshAsync(cancellationToken);
                    IsAccessTokenRefreshed = true;
                    IsAccessTokenRefreshRequired = false;
                }

                return await executeAsync();
            }
            catch (ValidationApiException exception)
            {
                OnExceptionCatched(exception, out bool isAccessTokenExpired);
                return await ReExecuteAsync(executeAsync, isAccessTokenExpired, cancellationToken);
            }
            catch (ApiException exception)
            {
                OnExceptionCatched(exception, out bool isAccessTokenExpired);
                return await ReExecuteAsync(executeAsync, isAccessTokenExpired, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<T> ReExecuteAsync<T>(Func<Task<T>> executeAsync, bool isAccessTokenExpired, CancellationToken cancellationToken = default)
        {
            if (isAccessTokenExpired)
            {
                IsAccessTokenRefreshRequired = true;
                return await ExecuteAsync(executeAsync, cancellationToken);
            }

            return default;
        }

        protected virtual void OnExceptionCatched(ValidationApiException exception, out bool isAccessTokenExpired)
        {
            isAccessTokenExpired = false;

            if (exception.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (!IsAccessTokenRefreshed && exception.Headers.Contains(ApiConstants.TokenExpiredHeader))
                    isAccessTokenExpired = true;
                else
                    throw new SorschiaUnauthorizedException(exception);
            }
            else if (exception.StatusCode == HttpStatusCode.Forbidden)
                throw new SorschiaForbiddenException(exception);
            else if (exception.Content != null && exception.Content.Type == ApiConstants.CustomErrorContentType)
                throw new SorschiaException(exception.Content.Detail, exception, true);
        }

        protected virtual void OnExceptionCatched(ApiException exception, out bool isAccessTokenExpired)
        {
            isAccessTokenExpired = false;

            if (exception.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (!IsAccessTokenRefreshed && exception.Headers.Contains(ApiConstants.TokenExpiredHeader))
                    isAccessTokenExpired = true;
                else
                    throw new SorschiaUnauthorizedException(exception);
            }
            else if (exception.StatusCode == HttpStatusCode.Forbidden)
                throw new SorschiaForbiddenException(exception);
        }
    }
}
