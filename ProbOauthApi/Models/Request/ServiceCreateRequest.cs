using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbOauthApi.Models.Request
{
    public class ServiceCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceForTransaction { get; set; }
    }
}
