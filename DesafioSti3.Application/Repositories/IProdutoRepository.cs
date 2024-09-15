using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ListarProdutos();
        Task<Produto> BuscarProdutoPorId(int id);
        Task<Produto> AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task ExcluirProduto(int id);
    }
}
