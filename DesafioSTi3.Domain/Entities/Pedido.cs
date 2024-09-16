using DesafioSTi3.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioSTi3.Domain.Entities
{
    public class Pedido
    {
        public Guid Identificador { get; set; }
        public  DateTime DataVenda { get; set; }
        
        public Cliente Cliente { get; set; }
        
        [JsonIgnore]
        public Guid ClienteId { get; set; }
        public decimal ValorFinal { get; set; }
        
        public ICollection<ItemPedido> Itens { get; set; }

        public void RegraDeDesconto()
        {
            decimal ValorParcial = Itens.Sum(item => item.PrecoUnitario * item.Quantidade);

            switch (Cliente.Categoria)
            {
                case CategoriaCliente.REGULAR when ValorParcial > (decimal)500.00:
                    ValorFinal = ValorParcial - (decimal)0.05 * ValorParcial;
                    break;
                case CategoriaCliente.PREMIUM when ValorParcial > (decimal)300.00:
                    ValorFinal = ValorParcial - (decimal)0.10 * ValorParcial;
                    break;
                case CategoriaCliente.VIP:
                    ValorFinal = ValorParcial - (decimal)0.15 * ValorParcial;
                    break;
            }
        }
    }

}
