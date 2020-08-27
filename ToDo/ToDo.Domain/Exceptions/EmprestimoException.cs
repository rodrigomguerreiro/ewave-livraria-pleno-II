using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Exceptions
{
    public class LimiteEmprestimoException : ExceptionBase
    {
        public LimiteEmprestimoException() : base("Usuário com limite de emprestimo.") { }

    }

    public class EmprestimoAtrasadoException : ExceptionBase
    {
        public EmprestimoAtrasadoException() : base("Usuário com empréstimo está atrasado.") { }

    }

    public class EmprestimoNaoEncontradoException : ExceptionBase
    {
        public EmprestimoNaoEncontradoException() : base("Empréstimo não encontrado.") { }

    }
}
