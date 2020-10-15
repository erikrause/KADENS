using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Domain.Entities;
using ProbOauthApi.Controllers.Abstract;
using ProbOauthApi.Models.Request;
using ProbOauthApi.Models.Response;
using MRI.OutgoingPorts;
//using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProbOauthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : CrudController<Clinic, ClinicCreateRequest, ClinicResponse>
    {
        public ClinicsController(IRepository repository) : base(repository)
        {
        }
    }
}
