using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Request
{
    public class PatientCreateRequest
    {
        public int DoctorId { get; set; }
        public string CardNumber { get; set; }
    }
}
