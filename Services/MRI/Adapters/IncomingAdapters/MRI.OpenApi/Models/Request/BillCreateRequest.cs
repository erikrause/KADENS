using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Request
{
    public class BillCreateRequest
    {
        public int BillNumber { get; protected set; }
        //public DateTime BillDate { get; protected set; }  заполняется в логике?
        public DateTime PaymentDate { get; protected set; }
        public bool IsPayed { get; protected set; }
        public string StatusDescription { get; protected set; }
        public decimal Amount { get; protected set; }
        public int BillStatus { get; protected set; }
    }
}
