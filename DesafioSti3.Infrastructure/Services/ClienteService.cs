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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            return await _clienteRepository.AdicionarCliente(cliente);
        }

        public async Task AtualizarCliente(Cliente cliente)
        {
            await _clienteRepository.AtualizarCliente(cliente);
        }

        public async Task<Cliente> BuscarClientePorId(Guid id)
        {
            return await _clienteRepository.BuscarClientePorId(id);
        }

        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            return await _clienteRepository.ListarClientes();
        }

        public async Task RemoverCliente(Guid id)
        {
            await _clienteRepository.RemoverCliente(id);
        }
    }
}
