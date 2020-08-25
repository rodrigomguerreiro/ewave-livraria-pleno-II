using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Exceptions
{
    public class UsuarioNaoEncontradoException : ExceptionBase
    {
        public UsuarioNaoEncontradoException() : base("Usuário não encontrado.") { }
    }
}
