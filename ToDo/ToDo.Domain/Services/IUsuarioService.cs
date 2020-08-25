using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Services
{
    public interface IUsuarioService
    {
        Task CriarAsync(Guid aggregateId, int instituicaoEnsinoId, string nome, string cpf, string telefone, string email);

        Task AtualizarAsync(Guid aggregateId, int instituicaoEnsinoId, string nome, string cpf, string telefone, string email);

        Task<IEnumerable<Usuario>> ListAll();
        Task<Usuario> ObterPorAsync(int id);

        Task InformarEndereco(Guid aggregateId, string logradouro, string bairro, string complemento, int numero);
    }
}
