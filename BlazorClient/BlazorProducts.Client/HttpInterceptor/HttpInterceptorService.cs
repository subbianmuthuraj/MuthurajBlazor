using Blazored.Toast.Services;
using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;
using Toolbelt.Blazor;

namespace BlazorProducts.Client.HttpInterceptor
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly NavigationManager _navManager;
        private readonly IToastService _toastService;
        private readonly RefreshTokenService _refreshTokenService;
        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager,
            IToastService toastService, RefreshTokenService refreshTokenService)
        {
            _interceptor = interceptor;
            _navManager = navManager;
            _toastService = toastService;
            _refreshTokenService = refreshTokenService;

        }

        public void RegisterEvent() => _interceptor.AfterSend += HandleResponse;

        public void registerBeforeSendEvent() =>
            _interceptor.BeforeSendAsync += InterceptorBeforeSendAsync;
        public void DisposeEvent()
        {
            _interceptor.AfterSend -= HandleResponse;
            _interceptor.BeforeSendAsync -= InterceptorBeforeSendAsync;
        }

        private async Task InterceptorBeforeSendAsync(object sender, HttpClientInterceptorEventArgs e)
        {
            var absolutePath = e.Request.RequestUri.AbsolutePath;

            if (!absolutePath.Contains("token") && !absolutePath.Contains("authentication"))
            {
                var token = await _refreshTokenService.TryRefreshToken();
                if (!string.IsNullOrEmpty(token))
                {
                    e.Request.Headers.Authorization =
                        new AuthenticationHeaderValue("bearer", token);
                }
            }
        }

        private void HandleResponse(object? sender, HttpClientInterceptorEventArgs e)
        {
            if (e.Response == null)
            {
                _navManager.NavigateTo("/error");
                throw new HttpResponseException("Server Not Available");
            }
            var message = "";
            if (!e.Response.IsSuccessStatusCode)
            {
                switch (e.Response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        _navManager.NavigateTo("/404");
                        message = "Resource Not Found.";
                        break;
                    case HttpStatusCode.BadRequest:
                        message = "Invalid Request Please Try again";
                        _toastService.ShowError(message);
                        break;
                    case HttpStatusCode.Unauthorized:
                        _navManager.NavigateTo("/unauthorized");
                        message = "Unauthorized access";
                        break;
                    default:
                        _navManager.NavigateTo("/error");
                        message = "Something Went Wrong..Plesae contact Administator...";
                        break;
                }
                throw new HttpResponseException(message);
            }

        }
    }
}
