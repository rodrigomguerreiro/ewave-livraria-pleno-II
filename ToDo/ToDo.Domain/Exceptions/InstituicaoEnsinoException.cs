using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Exceptions
{
    public class InstituicaoEnsinoNaoEncontradaException : ExceptionBase
    {
        public InstituicaoEnsinoNaoEncontradaException() : base("Instituição de ensino não encontrada.") { }
    }
}
