using DesafioSti3.Application.DTOs.Criacao;
using DesafioSti3.Application.Services;
using DesafioSTi3.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSTi3.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController(IProdutoService _produtoService) : ControllerBase
    {
        [HttpPost("AdicionarPedido")]
        public async Task<ActionResult> AdicionarPedido(ProdutoCriacaoDto produto)
        {
            await _produtoService.AdicionarProduto(produto);
            return Ok(produto);
        }

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<List<Produto>>> ListarProdutos()
        {
            var produtos = await _produtoService.ListarProdutos();
            return Ok(produtos);
        }
    }
}
