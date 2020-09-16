using MRI.OpenApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Response
{
    public class PaymentResponse : EntityResponse
    {
        public string Purpose { get; set; }
        public string BIK { get; set; }
        public string INN { get; set; }
        public decimal Amount { get; set; }
        public int ClinicId { get; set; }
        public int OperationStatus { get; set; }
    }
}
