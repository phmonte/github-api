using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace GithubAPI
{
    public class RefitHandler : DelegatingHandler
    {
        private readonly IOptions<GithubConfiguration> config;

        public RefitHandler(IOptions<GithubConfiguration> config)
        {
            this.config = config;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", config?.Value?.Token);
            request.Headers.Add("User-Agent", config?.Value?.User);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
