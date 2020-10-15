using ProbOauthApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbOauthApi.Models.Response
{
    public class ClinicResponse : EntityResponse
    {
        public string Name { get; set; }
        public string ContactAddress { get; set; }
        public string Phone { get; set; }
        public string BIK { get; set; }
        public string INN { get; set; }
    }
}
