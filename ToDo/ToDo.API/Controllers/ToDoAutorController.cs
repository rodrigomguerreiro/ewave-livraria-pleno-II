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
    [Route("api/autor")]
    public class ToDoAutorController : ToDoControllerBase
    {
        private readonly IAutorService _autorService;

        public ToDoAutorController(IUnitOfWork uow, IAutorService autorService) : base(uow)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<IEnumerable<Autor>> ListAllAsync()
        {
            return await _autorService.ListAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Autor> ObterPorIdAsync(int id)
        {
             return await _autorService.ObterPorAsync(id);
        }

        [HttpPost]
        public async Task CriarUsuarioAsync([FromBody] AutorDto dto)
        {
            var aggregateId = Guid.NewGuid();
            await _autorService.CriarAsync(aggregateId, dto.Nome, dto.Ativo);

            await UnitOfWork.SaveAsync();
        }

        [HttpPut("{aggregateId:guid}")]
        public async Task AtualizarAsync(Guid aggregateId, [FromBody] AutorDto dto)
        {
            await _autorService.AtualizarAsync(aggregateId, dto.Nome, dto.Ativo);

            await UnitOfWork.SaveAsync();
        }
    }
}
