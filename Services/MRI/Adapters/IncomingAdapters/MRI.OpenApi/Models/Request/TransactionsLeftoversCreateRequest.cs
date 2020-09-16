using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Request
{
    public class TransactionsLeftoversCreateRequest
    {
        public int ClinicId { get; set; }
        public int ServiceId { get; set; }
        public int TransactionsLeft { get; set; }
    }
}
