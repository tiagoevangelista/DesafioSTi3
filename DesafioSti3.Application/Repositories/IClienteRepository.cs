using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Application.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ListarClientes();
        Task<Cliente> BuscarClientePorId(Guid id);
        Task<Cliente> AdicionarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task RemoverCliente(Guid id);
    }
}
