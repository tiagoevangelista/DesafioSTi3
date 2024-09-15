using DesafioSti3.Application.Interfaces;
using DesafioSti3.Application.Services;
using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Infrastructure.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> ProcessarPedido(Pedido pedido)
        {
            //var valorFinal = pedido.Itens.Sum(pedido => pedido.PrecoFinal);
            //pedido.ValorFinal = valorFinal;

            return await _pedidoRepository.AdicionarPedido(pedido);
        }

        public async Task<IEnumerable<Pedido>> ListarPedidos ()
        {
            return await _pedidoRepository.ListarPedidos();
        }

        public async Task<Pedido> BuscarPedidoPorId(Guid id)
        {
            return await _pedidoRepository.BuscarPedidoPorId(id);
        }

        public async Task<Pedido> AdicionarPedido(Pedido pedido)
        {
            return await _pedidoRepository.AdicionarPedido(pedido);
        }

        public async Task AtualizarPedido(Pedido pedido)
        {
            await _pedidoRepository.AtualizarPedido(pedido);
        }

        public async Task RemoverPedido(Guid id)
        {
            await _pedidoRepository.RemoverPedido(id);
        }
    }
}
