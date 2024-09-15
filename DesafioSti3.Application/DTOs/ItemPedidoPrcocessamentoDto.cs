using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.DTOs
{
    public class ItemPedidoPrcocessamentoDto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
