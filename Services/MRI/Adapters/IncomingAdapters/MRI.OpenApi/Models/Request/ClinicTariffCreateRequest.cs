using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Request
{
    public class ClinicTariffCreateRequest
    {
        public int Id { get; set; }
        public int TariffId { get; set; }
        //public int ClinicId { get; set; }       // FK
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
