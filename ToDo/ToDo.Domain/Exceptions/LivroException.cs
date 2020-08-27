using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Exceptions
{
    public class LivroNaoEncontradoException : ExceptionBase
    {
        public LivroNaoEncontradoException() : base("Livro não encontrado.") { }
    }

    public class LivroEmprestadoException : ExceptionBase
    {
        public LivroEmprestadoException() : base("Este Livro está emprestado.") { }
    } 
}
