using DesafioSti3.Application.DTOs;
using DesafioSti3.Application.DTOs.Consulta;
using DesafioSti3.Application.DTOs.Criacao;
using DesafioSti3.Application.Services;
using DesafioSti3.Infrastructure.Services;
using DesafioSTi3.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSTi3.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidosController(
        IPedidoService _pedidoService,
        IClienteService _clienteService,
        IProdutoService _produtoService) : ControllerBase
    {

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<List<PedidoDto>>> ListarPedidos()
        {
            var produtos = await _pedidoService.ListarPedidos();
            return Ok(produtos);
        }

        [HttpGet("BuscarPedidoPorId/{id}")]
        public async Task<ActionResult<PedidoDto>> BuscarPedidoPorId(Guid id)
        {
            var pedido = await _pedidoService.BuscarPedidoPorId(id);

            var listaItens = new List<ItemPedidoDto>();

            foreach (var item in pedido.Itens)
            {
                var produtoAtual = await _produtoService.BuscarProdutoPorId(item.ProdutoId);
                var pedidoItem = new ItemPedidoDto()
                {
                    ProdutoId = item.ProdutoId,
                    Descricao = item.Produto.Descricao,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario
                };
                listaItens.Add(pedidoItem);
            }

            var pedidoDto = new PedidoDto()
            {
                Identificador = pedido.Identificador,
                DataVenda = pedido.DataVenda,
                Cliente = pedido.Cliente,
                Itens = listaItens
            };

            return Ok(pedidoDto);
        }

        [HttpPost("AdicionarPedido")]
        public async Task<ActionResult<Pedido>> AdicionarPedido(PedidoCriacaoDto pedidoDto)
        {
            var listaItens = new List<ItemPedido>();
            
            foreach (var item in pedidoDto.Itens)
            {
                var produtoAtual = await _produtoService.BuscarProdutoPorId(item.ProdutoId);
                var pedidoItem = new ItemPedido()
                {
                    ProdutoId = item.ProdutoId,
                    Produto = produtoAtual,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario,
                };
                listaItens.Add(pedidoItem); 
            }

            var pedido = new Pedido()
            {
                DataVenda = DateTime.UtcNow.ToLocalTime(),
                Cliente = await _clienteService.BuscarClientePorId(pedidoDto.Cliente.Id),
                Itens = listaItens,
                SubTotal = pedidoDto.Itens.Sum(item => item.PrecoUnitario * item.Quantidade),
            };

            pedido = await _pedidoService.AdicionarPedido(pedido);

            return Ok(pedido);
        }

        [HttpPost("ProcessarPedido")]
        public async Task<ActionResult> ProcessarPedido(PedidoDto pedidoDto)
        {
            return BadRequest();
        }
    }
}
