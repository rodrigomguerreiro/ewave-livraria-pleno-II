using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.DTOs
{
    public class InstituicaoEnsinoDto
    {
        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Telefone { get; set; }

        public bool Ativo { get; set; }

        public EnderecoDto Endereco { get; set; }
    }
}
