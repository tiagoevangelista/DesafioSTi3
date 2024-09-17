using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioSTi3.Domain.Entities;
using DesafioSti3.Infrastructure;
using DesafioSti3.Application.DTOs.Consulta;
using DesafioSti3.Application.DTOs.Criacao;
using DesafioSti3.Application.Services;

namespace DesafioSTi3.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController(IClienteService _clienteService) : ControllerBase
    {
        [HttpGet("ListarClientes")]
        public async Task<ActionResult<List<ClienteDto>>> ListarClientes()
        {
            return Ok(await _clienteService.ListarClientes());
        }

        [HttpPost("AdicionarCliente")]
        public async Task<ActionResult<Cliente>> AdicionarCliente(ClienteCriacaoDto clienteDto)
        {
            var cliente = new Cliente()
            {
                Nome = clienteDto.Nome,
                Categoria = clienteDto.Categoria,
                CPF = clienteDto.CPF,
            };

            await _clienteService.AdicionarCliente(cliente);

            return Ok(cliente);
        }

    }
}
