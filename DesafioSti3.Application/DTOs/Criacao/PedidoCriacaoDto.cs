using DesafioSti3.Application.DTOs.Consulta;
using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.DTOs.Criacao
{
    public class PedidoCriacaoDto
    {
        public ClienteDto Cliente { get; set; }
        public ICollection<ItemPedidoDto> Itens { get; set; }
    }
}
