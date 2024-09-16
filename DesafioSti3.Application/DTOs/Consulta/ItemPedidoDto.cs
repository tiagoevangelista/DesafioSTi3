namespace DesafioSti3.Application.DTOs.Consulta
{
    public class ItemPedidoDto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

    }
}