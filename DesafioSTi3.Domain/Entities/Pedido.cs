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

        [JsonIgnore]
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public ICollection<ItemPedido> Itens { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Descontos { get; set; }
        public decimal ValorTotal { get; set; }

        public void RegraDeDesconto()
        {
            switch (Cliente.Categoria)
            {
                case CategoriaCliente.REGULAR when SubTotal > (decimal)500.00:
                    Descontos = (decimal)0.05 * SubTotal;
                    break;
                case CategoriaCliente.PREMIUM when SubTotal > (decimal)300.00:
                    Descontos = (decimal)0.10 * SubTotal;
                    break;
                case CategoriaCliente.VIP:
                    Descontos = (decimal)0.15 * SubTotal;
                    break;
            }

            ValorTotal = SubTotal - Descontos;
        }
    }

}
