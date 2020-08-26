using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Infrastructure.Extensions;

namespace ToDo.Application.Services
{
    public class InstituicaoService : IInstituicaoEnsinoService
    {
        private readonly IInstituicaoEnsinoRepository _instituicaoRepository;

        public InstituicaoService(IInstituicaoEnsinoRepository instituicaoRespository)
        {
            _instituicaoRepository = instituicaoRespository;
        }

        public async Task CriarAsync(Guid aggregateId, string nome, string cnpj, string telefone, string logradouro, int numero, string bairro, string complemento)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (nome.IsNull()) throw new ArgumentNullException(nameof(nome));

            var instituicao = new InstituicaoEnsino
            {
                AggregateId = aggregateId,
                Nome = nome,
                Cnpj = cnpj,
                Telefone = telefone,
                Ativo = true,
                Endereco = new Endereco 
                {
                    Logradouro = logradouro,
                    Bairro = bairro,
                    Complemento = complemento,
                    Numero = numero
                }
            };

            await _instituicaoRepository.CreateAsync(instituicao);
        }

        public async Task AtualizarAsync(Guid aggregateId, string nome, string cnpj, string telefone, string logradouro, int numero, string bairro, string complemento, bool ativo)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            var instituicao = await _instituicaoRepository.GetByAggregateIdAsync(aggregateId);

            if (instituicao.IsNull()) throw new Exception("Instituição não encontrado.");
            instituicao.Nome = nome;
            instituicao.Cnpj = cnpj;
            instituicao.Telefone = telefone;
            instituicao.Ativo = ativo;
            instituicao.Endereco.Logradouro = logradouro;
            instituicao.Endereco.Bairro = bairro;
            instituicao.Endereco.Complemento = complemento;
            instituicao.Endereco.Numero = numero;

            await _instituicaoRepository.UpdateAsync(instituicao);
        }

        public async Task<IEnumerable<InstituicaoEnsino>> ListAll()
        {
            return await _instituicaoRepository.ListAll();
        }

        public async Task<InstituicaoEnsino> ObterPorAsync(int id)
        {
            return await _instituicaoRepository.GetByAsync(id);
        }
    }
}
