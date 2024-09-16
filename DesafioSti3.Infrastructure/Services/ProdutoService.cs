using DesafioSti3.Application.DTOs.Criacao;
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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task AtualizarProduto(Produto produto)
        {
            await _produtoRepository.AtualizarProduto(produto);
        }

        public async Task<Produto> BuscarProdutoPorId(int id)
        {
            return await _produtoRepository.BuscarProdutoPorId(id);
        }

        public async Task<Produto> AdicionarProduto(ProdutoCriacaoDto produto)
        {
            return await _produtoRepository.AdicionarProduto(produto);
        }

        public async Task ExcluirProduto(int id)
        {
            await _produtoRepository.ExcluirProduto(id);            
        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return await _produtoRepository.ListarProdutos();
        }
    }
}
