using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Domain.Entities;
using MRI.OpenApi.Controllers.Abstract;
using MRI.OpenApi.Models.Request;
using MRI.OpenApi.Models.Response;
using MRI.OutgoingPorts;
using MRI.PostgresRepository;

namespace MRI.OpenApi.Controllers
{
    /// <summary>
    /// Контроллер чеков
    /// </summary>
    [Authorize]
    [ApiController]
    public class BillsController : CrudController<Bill, BillCreateRequest, BillResponse>
    {
        public BillsController(IRepository repository) : base(repository)
        {
        }
    }
}
