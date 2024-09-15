using DesafioSti3.Application.Services;
using DesafioSTi3.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSTi3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarClientes()
        {
            var clientes = await _clienteService.ListarClientes();
            return Ok(clientes);
        }
    }
}
