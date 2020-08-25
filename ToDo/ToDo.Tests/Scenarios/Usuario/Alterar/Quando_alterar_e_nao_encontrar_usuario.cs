using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using ToDo.Application.Services;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using Xunit;

namespace ToDo.Tests.Scenarios.Usuario.Alterar
{
    public class Quando_alterar_e_nao_encontrar_usuario
    {
        private readonly UsuarioService _service;
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock = new Mock<IUsuarioRepository>();

        private readonly Guid _aggregateId = Guid.NewGuid();
        private readonly int _instituicaoEnsinoId = 1;
        private readonly string _nome = "Jhon Doe";
        private readonly string _cpf = "01709298711";
        private readonly string _telefone = "986788876";
        private readonly string _email = "eu@email.com";

        public Quando_alterar_e_nao_encontrar_usuario() 
        {
            _usuarioRepositoryMock.Setup(x => x.GetByAggregateIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Domain.Entities.Usuario>(null));
            _service = new UsuarioService(_usuarioRepositoryMock.Object, null);
        }

        [Fact]
        public void Quando_executar()
        {
            var action = new Action(() => _service.AtualizarAsync(_aggregateId, _instituicaoEnsinoId, _nome, _cpf, _telefone, _email).GetAwaiter().GetResult());
            action.Should().Throw<UsuarioNaoEncontradoException>();
        }
    }
}
