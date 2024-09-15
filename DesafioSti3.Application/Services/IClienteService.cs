using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ListarClientes();
        Task<Cliente> BuscarClientePorId(Guid id);
        Task<Cliente> AdicionarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task RemoverCliente(Guid id);
    }
}
