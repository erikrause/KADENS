using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Request
{
    public class ClinicCreateRequest
    {
        public string Name { get; set; }
        public string ContactAddress { get; set; }
        public string Phone { get; set; }
        public string BIK { get; set; }
        public string INN { get; set; }
    }
}
