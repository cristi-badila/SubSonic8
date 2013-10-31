namespace Client.Common
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class RedirectingHandler : HttpClientHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            try
            {
                response = await base.SendAsync(request, cancellationToken);
            }
            catch (Exception e)
            {
                response = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable) { ReasonPhrase = e.Message };
            }

            return IsRedirect(response) ? await base.SendAsync(GetRequestForRedirect(response), cancellationToken) : response;
        }

        private static bool IsRedirect(HttpResponseMessage response)
        {
            return response.StatusCode == HttpStatusCode.MovedPermanently
                   || response.StatusCode == HttpStatusCode.Moved
                   || response.StatusCode == HttpStatusCode.Redirect
                   || response.StatusCode == HttpStatusCode.Found
                   || response.StatusCode == HttpStatusCode.SeeOther
                   || response.StatusCode == HttpStatusCode.RedirectKeepVerb
                   || response.StatusCode == HttpStatusCode.TemporaryRedirect
                   || (int)response.StatusCode == 308;
        }

        private static HttpRequestMessage GetRequestForRedirect(HttpResponseMessage response)
        {
            var newRequest = CopyRequest(response.RequestMessage);
            if (response.StatusCode == HttpStatusCode.Redirect
                || response.StatusCode == HttpStatusCode.Found
                || response.StatusCode == HttpStatusCode.SeeOther)
            {
                newRequest.Content = null;
                newRequest.Method = HttpMethod.Get;
            }

            newRequest.RequestUri = response.Headers.Location;
            return newRequest;
        }

        private static HttpRequestMessage CopyRequest(HttpRequestMessage oldRequest)
        {
            var newRequest = new HttpRequestMessage(oldRequest.Method, oldRequest.RequestUri);
            foreach (var header in oldRequest.Headers)
            {
                newRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            foreach (var property in oldRequest.Properties)
            {
                newRequest.Properties.Add(property);
            }

            if (oldRequest.Content != null)
            {
                newRequest.Content = new StreamContent(oldRequest.Content.ReadAsStreamAsync().Result);
            }

            return newRequest;
        }
    }
}
