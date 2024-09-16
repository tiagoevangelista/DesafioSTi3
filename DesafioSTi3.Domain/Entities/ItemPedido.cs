using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioSTi3.Domain.Entities
{
    public class ItemPedido
    {
        [JsonIgnore]
        public Guid PedidoIdentificador { get; set; }
        [JsonIgnore]
        public Pedido Pedido { get; set; }
        [JsonIgnore]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
