using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Infrastructure.Extensions;

namespace ToDo.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRespository)
        {
            _livroRepository = livroRespository;
        }

        public async Task CriarAsync(Guid aggregateId, string titulo, string sinopse, string capa, int autorId, int generoId, int situacaoLivroId, bool ativo)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (titulo.IsNull()) throw new ArgumentNullException(nameof(titulo));

            var livro = new Livro
            {
                AggregateId = aggregateId,
                Titulo = titulo,
                Sinopse = sinopse,
                Capa = capa,
                AutorId = autorId,
                GeneroId = generoId,
                SituacaoLivroId = situacaoLivroId,
                Ativo = true

            };

            await _livroRepository.CreateAsync(livro);
        }

        public async Task AtualizarAsync(Guid aggregateId, string titulo, string sinopse, string capa, int autorId, int generoId, int situacaoLivroId, bool ativo)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            var livro = await _livroRepository.GetByAggregateIdAsync(aggregateId);

            if (livro.IsNull()) throw new Exception("Livro não encontrado.");
                livro.Titulo = titulo;
                livro.Sinopse = sinopse;
                livro.Capa = capa;
                livro.AutorId = autorId;
                livro.GeneroId = generoId;
                livro.SituacaoLivroId = situacaoLivroId;
                livro.Ativo = ativo;

            await _livroRepository.UpdateAsync(livro);
        }

        public async Task<IEnumerable<Livro>> ListAll()
        {
            return await _livroRepository.ListAll();
        }

        public async Task<Livro> ObterPorAsync(int id)
        {
            return await _livroRepository.GetByAsync(id);
        }
    }
}
