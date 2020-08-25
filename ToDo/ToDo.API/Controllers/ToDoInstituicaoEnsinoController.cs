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
    [Route("api/instituicao-ensino")]
    public class ToDoInstituicaoEnsinoController : ToDoControllerBase
    {
        private readonly IInstituicaoEnsinoService _instituicaoService;

        public ToDoInstituicaoEnsinoController(IUnitOfWork uow, IInstituicaoEnsinoService instituicaoService) : base(uow)
        {
            _instituicaoService = instituicaoService;
        }

        [HttpGet]
        public async Task<IEnumerable<InstituicaoEnsino>> ListAllAsync()
        {
            return await _instituicaoService.ListAll();
        }

        [HttpGet("{id:int}")]
        public async Task<InstituicaoEnsino> ObterPorIdAsync(int id)
        {
             return await _instituicaoService.ObterPorAsync(id);
        }

        [HttpPost]
        public async Task CriarUsuarioAsync([FromBody] InstituicaoEnsinoDto dto)
        {
            var aggregateId = Guid.NewGuid();
            await _instituicaoService.CriarAsync(aggregateId, dto.Nome, dto.Cnpj, dto.Telefone, dto.Endereco.Logradouro, dto.Endereco.Numero, dto.Endereco.Bairro, dto.Endereco.Complemento, dto.Ativo);

            await UnitOfWork.SaveAsync();
        }

        [HttpPut("{aggregateId:guid}")]
        public async Task AtualizarAsync(Guid aggregateId, [FromBody] InstituicaoEnsinoDto dto)
        {
            await _instituicaoService.AtualizarAsync(aggregateId, dto.Nome, dto.Cnpj, dto.Telefone, dto.Endereco.Logradouro, dto.Endereco.Numero, dto.Endereco.Bairro, dto.Endereco.Complemento, dto.Ativo);

            await UnitOfWork.SaveAsync();
        }
    }
}
