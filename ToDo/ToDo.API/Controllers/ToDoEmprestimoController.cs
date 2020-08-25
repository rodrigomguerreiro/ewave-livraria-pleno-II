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
    [Route("api/emprestimo")]
    public class ToDoEmprestimoController : ToDoControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;

        public ToDoEmprestimoController(IUnitOfWork uow, IEmprestimoService emprestimoService) : base(uow)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Emprestimo>> ListAllAsync()
        {
            return await _emprestimoService.ListAll();
        }

        [HttpPost]
        public async Task CriarAsync([FromBody] EmprestimoDto dto)
        {
            var aggregateId = Guid.NewGuid();
            await _emprestimoService.CriarAsync(aggregateId, dto.LivroId, dto.UsuarioId);

            await UnitOfWork.SaveAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Emprestimo> ObterPorIdAsync(int id)
        {
             return await _emprestimoService.ObterPorAsync(id);
        }


        [HttpPut("{aggregateId:guid}/encerrar-emprestimo")]
        public async Task EncerrarAsync(Guid aggregateId)
        {
            await _emprestimoService.EncerrarAsync(aggregateId);

            await UnitOfWork.SaveAsync();
        }
    }
}
