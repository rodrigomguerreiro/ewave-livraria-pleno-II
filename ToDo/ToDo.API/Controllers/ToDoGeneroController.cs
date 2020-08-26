using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.DTOs;
using ToDo.Domain.Entities;
using ToDo.Domain.Services;
using ToDo.Infrastructure.EF.UOW;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/genero")]
    public class ToDoGeneroController : ToDoControllerBase
    {
        private readonly IGeneroService _generoService;

        public ToDoGeneroController(IUnitOfWork uow, IGeneroService generoService) : base(uow)
        {
            _generoService = generoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> ListAllAsync()
        {
            return await _generoService.ListAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Genero> ObterPorIdAsync(int id)
        {
             return await _generoService.ObterPorAsync(id);
        }

        [HttpPost]
        public async Task CriarUsuarioAsync([FromBody] GeneroDto dto)
        {
            var aggregateId = Guid.NewGuid();
            await _generoService.CriarAsync(aggregateId, dto.Descricao);

            await UnitOfWork.SaveAsync();
        }

        [HttpPut("{aggregateId:guid}")]
        public async Task AtualizarAsync(Guid aggregateId, [FromBody] GeneroDto dto)
        {
            await _generoService.AtualizarAsync(aggregateId, dto.Descricao, dto.Ativo);

            await UnitOfWork.SaveAsync();
        }
    }
}
