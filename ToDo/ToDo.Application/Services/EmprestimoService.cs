using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Infrastructure.Extensions;

namespace ToDo.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly ILivroRepository _livroRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRespository, ILivroRepository livroRepository)
        {
            _emprestimoRepository = emprestimoRespository;
            _livroRepository = livroRepository;
        }

        public async Task CriarAsync(Guid aggregateId, int livroId, int usuarioId)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (livroId.IsLessZero()) throw new ArgumentNullException(nameof(livroId));
            if (usuarioId.IsLessZero()) throw new ArgumentNullException(nameof(usuarioId));

            var possueEmprestimosAtrasados = await _emprestimoRepository.PossuiEmprestimoAtrasadoPorUsuarioAsync(usuarioId);
            if (possueEmprestimosAtrasados) throw new EmprestimoAtrasadoException();


            var qtdEmprestimosAtivos = await _emprestimoRepository.GetEmprestimosAtivosPorUsuarioAsync(usuarioId);
            if (qtdEmprestimosAtivos >= 2) throw new LimiteEmprestimoException();

            var dataEmprestimo = DateTime.Now;

            var emprestimo = new Emprestimo
            {
                AggregateId = aggregateId,
                UsuarioId = usuarioId,
                DataEmprestimo = dataEmprestimo,
                DataVencimento = dataEmprestimo.AddDays(30),
                LivroId = livroId
            };

            var livro = await _livroRepository.GetByAsync(livroId);
            livro.SituacaoLivroId = 1;
            await _livroRepository.UpdateAsync(livro);

            await _emprestimoRepository.CreateAsync(emprestimo);
        }

        public async Task EncerrarAsync(Guid aggregateId)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            var emprestimo = await _emprestimoRepository.GetByAggregateIdAsync(aggregateId);

            emprestimo.DataDevolucao = DateTime.Now;

            await _emprestimoRepository.UpdateAsync(emprestimo);
        }

        public async Task<IEnumerable<Emprestimo>> ListAll()
        {
            return await _emprestimoRepository.ListAll();
        }
        public async Task<Emprestimo> ObterPorAsync(int id)
        {
            return await _emprestimoRepository.GetByAsync(id);
        }
        
    }
}
