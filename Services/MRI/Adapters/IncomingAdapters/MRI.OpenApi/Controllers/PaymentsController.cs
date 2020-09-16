using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Domain.Entities;
using MRI.OpenApi.Controllers.Abstract;
using MRI.OpenApi.Models.Request;
using MRI.OpenApi.Models.Response;
using MRI.OutgoingPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Controllers
{
    /// <summary>
    /// Контроллер счетов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : CrudController<Payment, PaymentCreateRequest, PaymentResponse>
    {
        public PaymentsController(IRepository repository) : base(repository)
        {
        }
    }
}
