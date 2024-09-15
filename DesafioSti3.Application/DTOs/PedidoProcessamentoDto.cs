using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.DTOs
{
    internal class PedidoProcessamentoDto
    {
        public Guid Identificador { get; set; }
        public DateTime DataVenda { get; set; }
        public ClienteProcessamentoDto Cliente { get; set; }
        public ICollection<ItemPedido> Itens { get; set; }
    }
}
