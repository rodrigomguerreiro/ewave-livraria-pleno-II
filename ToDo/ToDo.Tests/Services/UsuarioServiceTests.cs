using FluentAssertions;
using System;
using ToDo.Application.Services;
using Xunit;

namespace ToDo.Tests.Services
{
    public class UsuarioServiceTests
    {
        private readonly UsuarioService _service;
        private readonly Guid _aggregateId = Guid.NewGuid();
        private readonly int _instituicaoEnsinoId = 1;
        private readonly string _nome = "Jhon Doe";
        private readonly string _cpf = "01709298711";
        private readonly string _telefone = "986788876";
        private readonly string _email = "eu@email.com";

        public UsuarioServiceTests()
        {
            _service = new UsuarioService(null, null);
        }

        [Fact]
        public void Quando_criar_usuario_com_aggregateId_invalido() 
        {
            var action = new Action(() => _service.CriarAsync(default(Guid), _instituicaoEnsinoId, _nome, _cpf, _telefone, _email).GetAwaiter().GetResult());
            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("aggregateId");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quando_criar_usuario_com_instituicaoEnsinoId_invalido(int instituicaoEnsinoId)
        {
            var action = new Action(() => _service.CriarAsync(_aggregateId, instituicaoEnsinoId, _nome, _cpf, _telefone, _email).GetAwaiter().GetResult());
            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("instituicaoEnsinoId");
        }
    }
}
