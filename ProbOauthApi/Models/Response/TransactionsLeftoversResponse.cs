using ProbOauthApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbOauthApi.Models.Response
{
    public class TransactionsLeftoversResponse : EntityResponse
    {
        public int ClinicId { get; set; }
        public int ServiceId { get; set; }
        public int TransactionsLeft { get; set; }
    }
}
