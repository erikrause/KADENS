using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Domain.Entities;
using MRI.OpenApi.Models.Request;
using MRI.OpenApi.Models.Response;
using MRI.OutgoingPorts;
using MRI.PostgresRepository;

namespace MRI.OpenApi.Controllers
{
    /// <summary>
    /// Контроллер чеков.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        readonly IRepository _repo;
        readonly Mapper _mapper;

        public BillsController(IRepository repository)
        {
            _repo = repository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Bill, BillResponse>().ReverseMap();
                    cfg.CreateMap<Bill, BillCreateRequest>().ReverseMap();
                }));
        }
        /// <summary>
        /// Get list of Bills.
        /// </summary>
        /// <returns> List of bills. </returns>
        [HttpGet]
        public async Task<IEnumerable<BillResponse>> Get()
        {
            var bills = await _repo.GetAll<Bill>();
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Bill by id.
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<BillResponse> Get(int id)
        {
            var bill = await _repo.Get<Bill>(id);
            return _mapper.Map<BillResponse>(bill);
        }
    }
}
