using MRI.OpenApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Response
{
    public class DoctorResponse : EntityResponse
    {
        public int ClinicId { get; set; }
        public int UserId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
    }
}
