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
    [Route("api/situacao-livro")]
    public class ToDoSituacaoLivroController : ToDoControllerBase
    {
        private readonly ISituacaoLivroService _situacaoLivroService;

        public ToDoSituacaoLivroController(IUnitOfWork uow, ISituacaoLivroService situacaoLivroService) : base(uow)
        {
            _situacaoLivroService = situacaoLivroService;
        }

        [HttpGet]
        public async Task<IEnumerable<SituacaoLivro>> ListAllAsync()
        {
            return await _situacaoLivroService.ListAll();
        }

        [HttpGet("{id:int}")]
        public async Task<SituacaoLivro> ObterPorIdAsync(int id)
        {
            return await _situacaoLivroService.ObterPorAsync(id);
        }

        [HttpPost]
        public async Task CriarUsuarioAsync([FromBody] SituacaoLivroDto dto)
        {
            var aggregateId = Guid.NewGuid();
            await _situacaoLivroService.CriarAsync(aggregateId, dto.Descricao, dto.Ativo);

            await UnitOfWork.SaveAsync();
        }

        [HttpPut("{aggregateId:guid}")]
        public async Task AtualizarAsync(Guid aggregateId, [FromBody] SituacaoLivroDto dto)
        {
            await _situacaoLivroService.AtualizarAsync(aggregateId, dto.Descricao, dto.Ativo);

            await UnitOfWork.SaveAsync();
        }
    }
}
