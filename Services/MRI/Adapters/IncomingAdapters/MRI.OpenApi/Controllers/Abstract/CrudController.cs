using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MRI.OutgoingPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MRI.Domain.Entities.Abstract;
using Swashbuckle.AspNetCore.Annotations;
using MRI.OpenApi.Models.Abstract;
using MRI.Domain.Entities;
using MRI.OpenApi.Models.Response;

namespace MRI.OpenApi.Controllers.Abstract
{
    [ApiController]
    public abstract class CrudController<TEntity, TEntityCreateRequest, TEntityResponse> : ControllerBase
        where TEntity : Entity
        where TEntityCreateRequest : class
        where TEntityResponse : EntityResponse
    {
        protected readonly IRepository _repo;
        protected readonly Mapper _mapper;
        public CrudController(IRepository repository)
        {
            _repo = repository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TEntityResponse>().ReverseMap();
                cfg.CreateMap<TEntityCreateRequest, TEntity>();
            }));
        }
        /// <summary>
        /// Получить список
        /// </summary>
        /// <returns> List of entities. </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<IEnumerable<TEntityResponse>>> Get()
        {
            IEnumerable<TEntity> entities = await _repo.GetAll<TEntity>();
            return Ok(_mapper.Map<IEnumerable<TEntityResponse>>(entities));
        }

        /// <summary>
        /// Получить ресурс по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <returns></returns>
        /// <response code="404"> Ресурс не найден </response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        public virtual async Task<ActionResult<TEntityResponse>> Get(int id)
        {
            var entity = await _repo.Get<TEntity>(id);

            if (entity is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TEntityResponse>(entity));
        }

        /// <summary>
        /// Создать ресурс
        /// </summary>
        /// <param name="entityCreateRequest"> Ресурс </param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesDefaultResponseType]
        [HttpPost]
        public virtual async Task<ActionResult> Create([FromBody] TEntityCreateRequest entityCreateRequest)
        {
            TEntity entity = _mapper.Map<TEntity>(entityCreateRequest);
            await _repo.Save(entity);
            return CreatedAtAction(nameof(Get), entity.Id, _mapper.Map<TEntityResponse>(entity));
        }

        /// <summary>
        /// Удалить ресурс по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204"> Ресурс успешно удален </response>
        /// <response code="404"> Ресурс не найден </response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        public virtual async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repo.Remove<TEntity>(id);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
