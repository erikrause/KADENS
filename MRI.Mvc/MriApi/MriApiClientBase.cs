using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace MRI.Mvc.MriApi
{
    public class MriApiClientBase
    {
        public string BearerToken { get; set; }
        protected Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();
            
            if (BearerToken != null)
            {
                msg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", BearerToken);
            }

            return Task.FromResult(msg);
        }
    }
}
