using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Domain.Entities;
using MRI.OpenApi.Controllers.Abstract;
using MRI.OpenApi.Models.Request;
using MRI.OpenApi.Models.Response;
using MRI.OutgoingPorts;

namespace MRI.OpenApi.Controllers
{
    [ApiController]
    public class ClinicsTariffsController : CrudController<ClinicTariff, ClinicTariffCreateRequest, ClinicTariffResponse>
    {
        public ClinicsTariffsController(IRepository repository) : base(repository)
        {
        }
    }
}
