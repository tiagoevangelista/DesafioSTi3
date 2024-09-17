using DesafioSti3.Application.DTOs.Consulta;
using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDto>> ListarPedidos();
        Task<Pedido> BuscarPedidoPorId(Guid id);
        Task<Pedido> AdicionarPedido(Pedido pedido);
        Task AtualizarPedido(Pedido pedido);
        Task RemoverPedido(Guid id);

        Task<Pedido> ProcessarPedido(Guid id);
    }
}
