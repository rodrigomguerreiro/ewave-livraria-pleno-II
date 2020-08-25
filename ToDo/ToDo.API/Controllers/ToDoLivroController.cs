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
    [Route("api/livro")]
    public class ToDoLivroController : ToDoControllerBase
    {
        private readonly ILivroService _livroService;

        public ToDoLivroController(IUnitOfWork uow, ILivroService livroService) : base(uow)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IEnumerable<Livro>> ListAllAsync()
        {
            return await _livroService.ListAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Livro> ObterPorIdAsync(int id)
        {
             return await _livroService.ObterPorAsync(id);
        }

        [HttpPost]
        public async Task CriarLivroAsync([FromBody] LivroDto dto)
        {
            var aggregateId = Guid.NewGuid();
            await _livroService.CriarAsync(aggregateId, dto.Titulo, dto.Sinopse, dto.Capa, dto.AutorId, dto.GeneroId, dto.SituacaoLivroId, dto.Ativo);
            
            await UnitOfWork.SaveAsync();
        }

        [HttpPut("{aggregateId:guid}")]
        public async Task AtualizarAsync(Guid aggregateId, [FromBody] LivroDto dto)
        {
            await _livroService.AtualizarAsync(aggregateId, dto.Titulo, dto.Sinopse, dto.Capa, dto.AutorId, dto.GeneroId, dto.SituacaoLivroId, dto.Ativo);

            await UnitOfWork.SaveAsync();
        }
    }
}
