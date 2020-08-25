using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using ToDo.Application.Services;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using Xunit;

namespace ToDo.Tests.Scenarios.Usuario.Criar
{
    public class Quando_criar_e_nao_encontrar_instituicao_ensino
    {
        private readonly UsuarioService _service;
        private readonly Mock<IInstituicaoEnsinoRepository> _instituicaoEnsinoRepositoryMock = new Mock<IInstituicaoEnsinoRepository>();
        
        private readonly Guid _aggregateId = Guid.NewGuid();
        private readonly int _instituicaoEnsinoId = 1;
        private readonly string _nome = "Jhon Doe";
        private readonly string _cpf = "01709298711";
        private readonly string _telefone = "986788876";
        private readonly string _email = "eu@email.com";

        public Quando_criar_e_nao_encontrar_instituicao_ensino()
        {
            _instituicaoEnsinoRepositoryMock.Setup(x => x.GetByAsync(It.IsAny<int>())).Returns(Task.FromResult<InstituicaoEnsino>(null));
            _service = new UsuarioService(null, _instituicaoEnsinoRepositoryMock.Object);
        }
        
        [Fact]
        public void Quando_executar() 
        {
            var action = new Action(() => _service.CriarAsync(_aggregateId, _instituicaoEnsinoId, _nome, _cpf, _telefone, _email).GetAwaiter().GetResult());
            action.Should().Throw<InstituicaoEnsinoNaoEncontradaException>();
        }

    }
}
