﻿using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsLeftoversController : CrudController<TransactionsLeftovers, TransactionsLeftoversCreateRequest, TransactionsLeftoversResponse>
    {
        public TransactionsLeftoversController(IRepository repository) : base(repository)
        {
        }
    }
}
