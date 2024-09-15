using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSTi3.Domain.Entities
{
    public class Pedido
    {
        public Guid Identificador { get; set; }
        public  DateTime DataVenda { get; set; }
        public Cliente Cliente { get; set; }
        public decimal ValorFinal { get; set; }

        public Guid ClienteId { get; set; }
        public ICollection<ItemPedido> Itens { get; set; }
    }
}
