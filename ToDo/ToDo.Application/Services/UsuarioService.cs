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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IInstituicaoEnsinoRepository _instituicaoEnsinoRepository;

        public UsuarioService(IUsuarioRepository userRespository, IInstituicaoEnsinoRepository instituicaoEnsinoRespository)
        {
            _userRepository = userRespository;
            _instituicaoEnsinoRepository = instituicaoEnsinoRespository;
        }

        public async Task CriarAsync(Guid aggregateId, int instituicaoEnsinoId, string nome, string cpf, string telefone, string email)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (instituicaoEnsinoId.IsLessZero()) throw new ArgumentNullException(nameof(instituicaoEnsinoId));
            if (nome.IsNull()) throw new ArgumentNullException(nameof(nome));
            if (cpf.IsNull()) throw new ArgumentNullException(nameof(cpf));
            if (telefone.IsNull()) throw new ArgumentNullException(nameof(telefone));
            if (email.IsNull()) throw new ArgumentNullException(nameof(email));

            var instituicao = await _instituicaoEnsinoRepository.GetByAsync(instituicaoEnsinoId);
            if (instituicao.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();

            var usuario = new Usuario
            {
                AggregateId = aggregateId,
                Nome = nome,
                Cpf = cpf,
                Telefone = telefone,
                Email = email,
                Ativo = true,
                InstituicaoEnsinoId = instituicaoEnsinoId

            };

            await _userRepository.CreateAsync(usuario);
        }

        public async Task AtualizarAsync(Guid aggregateId, int instituicaoEnsinoId, string nome, string cpf, string telefone, string email, bool ativo)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));
            if (instituicaoEnsinoId.IsLessZero()) throw new ArgumentNullException(nameof(instituicaoEnsinoId));
            if (nome.IsNull()) throw new ArgumentNullException(nameof(nome));
            if (cpf.IsNull()) throw new ArgumentNullException(nameof(cpf));
            if (telefone.IsNull()) throw new ArgumentNullException(nameof(telefone));
            if (email.IsNull()) throw new ArgumentNullException(nameof(email));

            var usuario = await _userRepository.GetByAggregateIdAsync(aggregateId);
            if (usuario.IsNull()) throw new UsuarioNaoEncontradoException();

            var instituicao = await _instituicaoEnsinoRepository.GetByAsync(instituicaoEnsinoId);
            if (instituicao.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();

            usuario.Nome = nome;
            usuario.Cpf = cpf;
            usuario.Telefone = telefone;
            usuario.Email = email;
            usuario.Ativo = ativo;
            usuario.InstituicaoEnsinoId = instituicaoEnsinoId;

            await _userRepository.UpdateAsync(usuario);
        }

        public async Task<IEnumerable<Usuario>> ListAll()
        {
            return await _userRepository.ListAll();
        }

        public async Task<Usuario> ObterPorAsync(int id)
        {
            return await _userRepository.GetByAsync(id);
        }

        public async Task InformarEndereco(Guid aggregateId, string logradouro, string bairro, string complemento, int numero)
        {
            if (aggregateId == Guid.Empty) throw new ArgumentNullException(nameof(aggregateId));

            var usuario = await _userRepository.GetByAggregateIdAsync(aggregateId);
            if (usuario.Endereco.IsNull())
            {
                usuario.Endereco = new Endereco
                {
                    Logradouro = logradouro,
                    Bairro = bairro,
                    Complemento = complemento,
                    Numero = numero
                };
            }
            else
            {
                usuario.Endereco.Logradouro = logradouro;
                usuario.Endereco.Bairro = bairro;
                usuario.Endereco.Complemento = complemento;
                usuario.Endereco.Numero = numero;
            }

            await _userRepository.UpdateAsync(usuario);
        }
    }
}
