using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
//using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Domain.Entities;
using ProbOauthApi.Controllers.Abstract;
using ProbOauthApi.Models.Request;
using ProbOauthApi.Models.Response;
using MRI.OutgoingPorts;

namespace ProbOauthApi.Controllers
{
    /// <summary>
    /// Контроллер чеков
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : CrudController<Bill, BillCreateRequest, BillResponse>
    {
        public BillsController(IRepository repository) : base(repository)
        {
        }
    }
}
