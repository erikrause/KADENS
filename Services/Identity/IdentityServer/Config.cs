using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
                    new ApiScope("api1", "My API")
        };
    }
}
