using MRI.OpenApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Response
{
    public class PatientResponse : EntityResponse
    {
        public int DoctorId { get; set; }
        public string CardNumber { get; set; }
    }
}
