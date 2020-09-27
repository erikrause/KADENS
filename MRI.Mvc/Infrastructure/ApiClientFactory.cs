using Microsoft.Extensions.Configuration;
using MriApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.Mvc.Infrastructure
{
    public class ApiClientFactory
    {
        readonly IConfiguration _configuration;
        public ApiClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Client CreateClient()
        {
            return new Client(_configuration.GetSection("ApiUrl").GetSection("Mri").Value, new System.Net.Http.HttpClient());
        }
    }
}
