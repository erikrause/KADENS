using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbOauthApi.Models.Request
{
    public class TariffForServiceCreateRequest
    {
        public int TariffId { get; set; }
        public int ServiceId { get; set; }
        public int TransactionsCount { get; set; }
    }
}
