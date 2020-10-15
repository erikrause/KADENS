using ProbOauthApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbOauthApi.Models.Response
{
    public class BillResponse : EntityResponse
    {
        public int BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPayed { get; set; }
        public string StatusDescription { get; set; }
        public decimal Amount { get; set; }
        public int BillStatus { get; set; }
    }
}
