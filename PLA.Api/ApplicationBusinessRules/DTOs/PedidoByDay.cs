namespace PLA.Api.ApplicationBusinessRules.DTOs;

public class PedidoByDay
{
    public DateTime Dia { get; set; }
    public List<PedidoDTO> Pedidos { get; set; }
}
