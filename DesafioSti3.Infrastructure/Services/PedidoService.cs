using DesafioSti3.Application.DTOs.Consulta;
using DesafioSti3.Application.DTOs.Faturamento;
using DesafioSti3.Application.Interfaces;
using DesafioSti3.Application.Services;
using DesafioSTi3.Domain.Entities;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSti3.Infrastructure.Services
{
    public class PedidoService(IPedidoRepository _pedidoRepository, HttpClient _httpClient) : IPedidoService
    {
        public async Task<Pedido> ProcessarPedido(Guid id)
        {
            var pedido = await _pedidoRepository.BuscarPedidoPorId(id);

            if (pedido == null)
                throw new ArgumentException(message: "Nenhum pedido localizado!");

            var sumarioPedido = new SumarioPedidoDto()
            {
                Identificador = pedido.Identificador,
                SubTotal = pedido.SubTotal,
                Descontos = pedido.Descontos,
                ValorTotal = pedido.ValorTotal,
                Itens = pedido.Itens.Select(item => new SumarioItemPedidoDto()
                {
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario,
                }).ToList()
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://sti3-faturamento.azurewebsites.net/api/vendas");
            request.Headers.Add("email", "tiagoefreires@gmail.com");
            request.Content = JsonContent.Create(sumarioPedido);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                BackgroundJob.Schedule(() => ProcessarPedido(id), DateTime.UtcNow.AddSeconds(15));
            }

            //if (DateTime.UtcNow.Minute < 09)
            //{
            //    Console.WriteLine(DateTime.UtcNow.Minute);
            //    BackgroundJob.Schedule(() => ProcessarPedido(id), DateTime.UtcNow.AddSeconds(5));
            //}

            Console.WriteLine(response);
            return pedido;

        }

        public async Task<IEnumerable<PedidoDto>> ListarPedidos ()
        {
            var pedidos = await _pedidoRepository.ListarPedidos();
            var pedidosDto = pedidos.Select(pedido => new PedidoDto
            {
                Identificador = pedido.Identificador,
                DataVenda = pedido.DataVenda,
                Cliente = pedido.Cliente,
                Itens = pedido.Itens.Select(item => new ItemPedidoDto
                    { 
                        ProdutoId = item.ProdutoId,
                        Descricao = item.Produto.Descricao,
                        Quantidade = item.Quantidade,
                        PrecoUnitario = item.PrecoUnitario
                    }).ToList()
            }).ToList();

            return pedidosDto;
        }

        public async Task<Pedido> BuscarPedidoPorId(Guid id)
        {
            return await _pedidoRepository.BuscarPedidoPorId(id);
        }

        public async Task<Pedido> AdicionarPedido(Pedido pedido)
        {
            pedido.RegraDeDesconto();
            return await _pedidoRepository.AdicionarPedido(pedido);
        }

        public async Task AtualizarPedido(Pedido pedido)
        {
            await _pedidoRepository.AtualizarPedido(pedido);
        }

        public async Task RemoverPedido(Guid id)
        {
            await _pedidoRepository.RemoverPedido(id);
        }
    }
}
