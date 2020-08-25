using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Services
{
    public interface IInstituicaoEnsinoService
    {
        Task CriarAsync(Guid aggregateId, string nome, string cnpj, string telefone, string logradouro, int numero, string bairro, string complemento, bool ativo);

        Task AtualizarAsync(Guid aggregateId, string nome, string cnpj, string telefone, string logradouro, int numero, string bairro, string complemento, bool ativo);

        Task<IEnumerable<InstituicaoEnsino>> ListAll();
        Task<InstituicaoEnsino> ObterPorAsync(int id);
    }
}
