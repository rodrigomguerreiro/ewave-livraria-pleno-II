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
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRespository)
        {
            _autorRepository = autorRespository;
        }

        public async Task CriarAsync(Guid aggregateId, string nome)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (nome.IsNull()) throw new ArgumentNullException(nameof(nome));

            var autor = new Autor
            {
                AggregateId = aggregateId,
                Nome = nome,
                Ativo = true

            };

            await _autorRepository.CreateAsync(autor);
        }

        public async Task AtualizarAsync(Guid aggregateId, string nome, bool ativo)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (nome.IsNull()) throw new ArgumentNullException(nameof(nome));

            var autor = await _autorRepository.GetByAggregateIdAsync(aggregateId);
            if (autor.IsNull()) throw new AutorNaoEncontradoException();

            autor.Nome = nome;
            autor.Ativo = ativo;

            await _autorRepository.UpdateAsync(autor);
        }

        public async Task<IEnumerable<Autor>> ListAll()
        {
            return await _autorRepository.ListAll();
        }

        public async Task<Autor> ObterPorAsync(int id)
        {
            return await _autorRepository.GetByAsync(id);
        }
    }
}
