using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioSti3.Application.DTOs.Consulta
{
    public class PedidoDto
    {
        public Guid Identificador { get; set; }
        public DateTime DataVenda { get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<ItemPedidoDto> Itens { get; set; }
    }
}
