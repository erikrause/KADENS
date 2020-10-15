using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Domain.Entities;
using ProbOauthApi.Controllers.Abstract;
using ProbOauthApi.Models.Request;
using ProbOauthApi.Models.Response;
using MRI.OutgoingPorts;

namespace ProbOauthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsTariffsController : CrudController<ClinicTariff, ClinicTariffCreateRequest, ClinicTariffResponse>
    {
        public ClinicsTariffsController(IRepository repository) : base(repository)
        {
        }
    }
}
