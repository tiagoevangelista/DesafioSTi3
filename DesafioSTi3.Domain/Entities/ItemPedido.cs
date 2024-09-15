using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSTi3.Domain.Entities
{
    public class ItemPedido
    {
        public Guid PedidoIdentificador { get; set; }
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
