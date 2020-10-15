using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbOauthApi.Models.Request
{
    public class TariffCreateRequest
    {
        public ulong RequestsCount { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsEnabled { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
