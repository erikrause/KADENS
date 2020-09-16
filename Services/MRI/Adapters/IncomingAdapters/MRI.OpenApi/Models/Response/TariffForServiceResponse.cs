using MRI.OpenApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Response
{
    public class TariffForServiceResponse : EntityResponse
    {
        public int TariffId { get; set; }
        public int ServiceId { get; set; }
        public int TransactionsCount { get; set; }
    }
}
