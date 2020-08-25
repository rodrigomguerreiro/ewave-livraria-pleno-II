using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.DTOs
{
   public class EnderecoDto
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
    }
}
