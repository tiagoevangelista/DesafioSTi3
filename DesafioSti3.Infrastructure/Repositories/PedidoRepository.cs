using DesafioSti3.Application.Interfaces;
using DesafioSTi3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> AdicionarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task AtualizarPedido(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> BuscarPedidoPorId(Guid id)
        {
            return await _context.Pedidos.Include(pedido => pedido.Itens).FirstOrDefaultAsync(pedido => pedido.Identificador == id);
        }

        public async Task<IEnumerable<Pedido>> ListarPedidos()
        {
            return await _context.Pedidos.Include(pedido => pedido.Itens).ToListAsync();
        }

        public async Task RemoverPedido(Guid id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(pedido => pedido.Identificador == id);

            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
        }
    }
}
