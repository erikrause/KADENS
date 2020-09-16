using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Request
{
    public class BillCreateRequest
    {
        public int BillNumber { get; set; }
        public DateTime BillDate { get; set; }  // заполняется в логике?
        public DateTime PaymentDate { get; set; }
        public bool IsPayed { get; set; }
        public string StatusDescription { get; set; }
        public decimal Amount { get; set; }
        public int BillStatus { get; set; }
    }
}
