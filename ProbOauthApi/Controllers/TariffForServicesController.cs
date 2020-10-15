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
    public class TariffForServicesController : CrudController<TariffForService, TariffForServiceCreateRequest, TariffForServiceResponse>
    {
        public TariffForServicesController(IRepository repository) : base(repository)
        {
        }
    }
}
