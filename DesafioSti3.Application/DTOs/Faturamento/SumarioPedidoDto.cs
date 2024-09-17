using DesafioSti3.Application.DTOs.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.DTOs.Faturamento
{
    public class SumarioPedidoDto
    {
        public Guid Identificador { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descontos  { get; set; }
        public decimal ValorTotal { get; set; }
        public ICollection<SumarioItemPedidoDto> Itens { get; set; }
    }
}
