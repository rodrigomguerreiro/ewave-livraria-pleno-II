using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Infrastructure.Extensions;

namespace ToDo.Application.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRespository)
        {
            _generoRepository = generoRespository;
        }

        public async Task CriarAsync(Guid aggregateId, string descricao, bool ativo)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (descricao.IsNull()) throw new ArgumentNullException(nameof(descricao));

            var genero = new Genero
            {
                AggregateId = aggregateId,
                Descricao = descricao,
                Ativo = true

            };

            await _generoRepository.CreateAsync(genero);
        }

        public async Task AtualizarAsync(Guid aggregateId, string descricao, bool ativo)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            var genero = await _generoRepository.GetByAggregateIdAsync(aggregateId);

            if (genero.IsNull()) throw new Exception("Genero não encontrado.");
            genero.Descricao = descricao;
            genero.Ativo = ativo;

            await _generoRepository.UpdateAsync(genero);
        }

        public async Task<IEnumerable<Genero>> ListAll()
        {
            return await _generoRepository.ListAll();
        }

        public async Task<Genero> ObterPorAsync(int id)
        {
            return await _generoRepository.GetByAsync(id);
        }
    }
}
