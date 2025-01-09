using System.Text.Json;

namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidoHandler : IObtenerPedidoInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ObtenerPedidoHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<PedidoDTO> Handler(long idPedido, int idUsuario)
    {
        if (idPedido.Equals(0))
            return null;

        var pedido = await _pedidosRepocitory.GetPedidoById(idPedido);
        if(pedido.IsNull())
            return null;

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.Obtencion,
            IdUsuario = idUsuario,
            IdRegistro = pedido.Id,
            NombreTabla = "Pedidos",
            NuevoValor = JsonSerializer.Serialize(pedido),
            AntiguoValor = JsonSerializer.Serialize(pedido),
            FechaRegistro = DateTime.UtcNow
        });

        return new PedidoDTO
        {
            Id = pedido.Id,
            NombreCliente = pedido.NombreCliente,
            Comentario = pedido.Comentario,
            Descripcion = pedido.Descripcion,
            Presio = pedido.Presio,
            Anticipo = pedido.Anticipo,
            FechaEntrega = pedido.FechaEntrega,
            Direccion = pedido.Direccion,
            Estatus = pedido.Estatus,
            Ubicacion = (0, 0)
        };
    }
}