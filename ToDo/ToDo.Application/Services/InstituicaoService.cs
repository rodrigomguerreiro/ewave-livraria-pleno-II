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
            if (cnpj.IsNull()) throw new ArgumentNullException(nameof(cnpj));
            if (telefone.IsNull()) throw new ArgumentNullException(nameof(telefone));
            if (logradouro.IsNull()) throw new ArgumentNullException(nameof(logradouro));
            if (numero.IsNull()) throw new ArgumentNullException(nameof(numero));
            if (bairro.IsNull()) throw new ArgumentNullException(nameof(bairro));
            if (complemento.IsNull()) throw new ArgumentNullException(nameof(complemento));

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
            var instituicao = await _instituicaoRepository.GetByAggregateIdAsync(aggregateId);
            if (instituicao.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();
            if (nome.IsNull()) throw new ArgumentNullException(nameof(nome));
            if (cnpj.IsNull()) throw new ArgumentNullException(nameof(cnpj));
            if (telefone.IsNull()) throw new ArgumentNullException(nameof(telefone));
            if (logradouro.IsNull()) throw new ArgumentNullException(nameof(logradouro));
            if (numero.IsNull()) throw new ArgumentNullException(nameof(numero));
            if (bairro.IsNull()) throw new ArgumentNullException(nameof(bairro));
            if (complemento.IsNull()) throw new ArgumentNullException(nameof(complemento));

            instituicao.Nome = nome;
            instituicao.Cnpj = cnpj;
            instituicao.Telefone = telefone;
            instituicao.Endereco.Logradouro = logradouro;
            instituicao.Endereco.Numero = numero;
            instituicao.Endereco.Bairro = bairro;
            instituicao.Endereco.Complemento = complemento;
            instituicao.Ativo = ativo;
            

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
