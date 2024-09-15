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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AtualizarProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> BuscarProdutoPorId(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task ExcluirProduto(int id)
        {
            var produto = await _context.FindAsync<Produto>(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }
    }
}
