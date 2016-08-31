using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerDrinkin.Utils;
using Microsoft.WindowsAzure.MobileServices;

namespace BeerDrinkin.AzureClient
{
    class AuthHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var client = ServiceLocator.Instance.Resolve<IAzureClient>()?.Client as MobileServiceClient;
            if (client == null)
            {
                throw new InvalidOperationException("Make sure to set the ServiceLocator has an instance of IAzureClient");
            }

            // Cloning the request, in case we need to send it again
            var clonedRequest = await CloneRequest(request);
            var response = await base.SendAsync(clonedRequest, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // The user isn't logged in so we'll go ahead and present them with a login screen.
                try
                {
                    await client.LoginAsync(MobileServiceAuthenticationProvider.Facebook, null);
                }
                catch (InvalidOperationException)
                {
                    // user cancelled auth, so lets return the original response
                    return response;
                }
            }
            return response;
        }

        private async Task<HttpRequestMessage> CloneRequest(HttpRequestMessage request)
        {
            var result = new HttpRequestMessage(request.Method, request.RequestUri);
            foreach (var header in request.Headers)
            {
                result.Headers.Add(header.Key, header.Value);
            }

            if (request.Content?.Headers.ContentType != null)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                var mediaType = request.Content.Headers.ContentType.MediaType;
                result.Content = new StringContent(requestBody, Encoding.UTF8, mediaType);
                foreach (var header in request.Content.Headers)
                {
                    if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        result.Content.Headers.Add(header.Key, header.Value);
                    }
                }
            }
            return result;
        }
    }
}
