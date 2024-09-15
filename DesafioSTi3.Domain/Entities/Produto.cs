using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSTi3.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
    }
}
