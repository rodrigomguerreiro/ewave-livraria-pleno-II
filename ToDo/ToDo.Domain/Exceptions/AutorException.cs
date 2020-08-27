using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Exceptions
{
    public class AutorNaoEncontradoException : ExceptionBase
    {
        public AutorNaoEncontradoException() : base("Usuário não encontrado.") { }
    }
}
