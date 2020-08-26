using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Infrastructure.Extensions;

namespace ToDo.Application.Services
{
    public class SituacaoLivroService : ISituacaoLivroService
    {
        private readonly ISituacaoLivroRepository _situacaoLivroRepository;

        public SituacaoLivroService(ISituacaoLivroRepository situacaoLivroRespository)
        {
            _situacaoLivroRepository = situacaoLivroRespository;
        }

        public async Task CriarAsync(Guid aggregateId, string descricao)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (descricao.IsNull()) throw new ArgumentNullException(nameof(descricao));

            var situacaoLivro = new SituacaoLivro
            {
                AggregateId = aggregateId,
                Descricao = descricao,
                Ativo = true

            };

            await _situacaoLivroRepository.CreateAsync(situacaoLivro);
        }

        public async Task AtualizarAsync(Guid aggregateId, string descricao, bool ativo)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            var situacaoLivro = await _situacaoLivroRepository.GetByAggregateIdAsync(aggregateId);

            if (situacaoLivro.IsNull()) throw new Exception("Situação de livro não encontrado.");
            situacaoLivro.Descricao = descricao;
            situacaoLivro.Ativo = ativo;

            await _situacaoLivroRepository.UpdateAsync(situacaoLivro);
        }

        public async Task<IEnumerable<SituacaoLivro>> ListAll()
        {
            return await _situacaoLivroRepository.ListAll();
        }

        public async Task<SituacaoLivro> ObterPorAsync(int id)
        {
            return await _situacaoLivroRepository.GetByAsync(id);
        }
    }
}
