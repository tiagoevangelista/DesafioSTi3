using DesafioSti3.Application.Services;
using DesafioSti3.Infrastructure.Services;
using DesafioSTi3.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSTi3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("CriarPedido")]
        public async Task<IActionResult> CriarPedido(Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            var resultado = await _pedidoService.ProcessarPedido(pedido);

            return Ok(resultado);
        }

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<List<Pedido>>> ListarPedidos()
        {
            var pedidos = await _pedidoService.ListarPedidos();

            return Ok(pedidos);
        }

        [HttpGet("BuscarPedidoPorId")]
        public async Task<ActionResult<List<Pedido>>> BuscarPedidoPorId(Guid id)
        {
            var pedidos = await _pedidoService.ListarPedidos();

            return Ok(pedidos);
        }

        [HttpPut("AtualizarPedido")]
        public async Task<ActionResult> AtualizarPedido(Pedido pedido)
        {
            await _pedidoService.AtualizarPedido(pedido);
            return Ok(pedido);
        }

        [HttpDelete("ExcluirPedido")]
        public async Task<ActionResult> ExcluirPedido(Guid id)
        {
            await _pedidoService.RemoverPedido(id);
            return Ok();
        }
    }
}
