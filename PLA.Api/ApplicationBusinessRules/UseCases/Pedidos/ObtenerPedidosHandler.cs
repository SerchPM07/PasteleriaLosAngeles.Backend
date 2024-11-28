using System.Text.Json;

namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidosHandler : IObtenerPedidosInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ObtenerPedidosHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<List<PedidoDTO>> Handler(DateTime dateTimeStart, DateTime dateTimeEnd, int idUsuario)
    {
        var pedidos = await _pedidosRepocitory.GetPedidosByDateTime(dateTimeStart, dateTimeEnd);

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.ObtencionMasiva,
            IdUsuario = idUsuario,
            IdRegistro = 0,
            NombreTabla = "Pedidos",
            AntiguoValor = JsonSerializer.Serialize(pedidos),
            NuevoValor = JsonSerializer.Serialize(pedidos),
            FechaRegistro = DateTime.UtcNow
        });

        return pedidos.Select(s => new PedidoDTO
        {
            Id = s.Id,
            NombreCliente = s.NombreCliente,
            Comentario = s.Comentario,
            Descripcion = s.Descripcion,
            Presio = s.Presio,
            Anticipo = s.Anticipo,
            FechaEntrega = s.FechaEntrega,
            Direccion = s.Direccion,
            Ubicacio = s.Ubicacio
        }).ToList();
    }
}
