using DesafioSTi3.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.DTOs.Criacao
{
    public class ClienteCriacaoDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public CategoriaCliente Categoria { get; set; }
    }
}
