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
    [Route("api/usuario")]
    public class ToDoUsuarioController : ToDoControllerBase
    {
        private readonly IUsuarioService _userService;

        public ToDoUsuarioController(IUnitOfWork uow, IUsuarioService userService) : base(uow)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> ListAllAsync()
        {
            return await _userService.ListAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Usuario> ObterPorIdAsync(int id)
        {
             return await _userService.ObterPorAsync(id);
        }

        [HttpPost]
        public async Task CriarUsuarioAsync([FromBody] UsuarioDto dto)
        {
            var aggregateId = Guid.NewGuid();
            await _userService.CriarAsync(aggregateId, dto.InstituicaoEnsinoId, dto.Nome, dto.Cpf, dto.Telefone, dto.Email);

            await UnitOfWork.SaveAsync();
        }

        [HttpPut("{aggregateId:guid}")]
        public async Task AtualizarAsync(Guid aggregateId, [FromBody] UsuarioDto dto)
        {
            await _userService.AtualizarAsync(aggregateId, dto.InstituicaoEnsinoId, dto.Nome, dto.Cpf, dto.Telefone, dto.Email);

            await UnitOfWork.SaveAsync();
        }

        [HttpPut("{aggregateId:guid}/informar-endereco")]
        public async Task InformarEnderecoAsync(Guid aggregateId, [FromBody] EnderecoDto dto)
        {
            await _userService.InformarEndereco(aggregateId, dto.Logradouro, dto.Bairro, dto.Complemento, dto.Numero);

            await UnitOfWork.SaveAsync();
        }
    }
}
