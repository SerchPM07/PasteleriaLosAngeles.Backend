namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ActualizarPedidoHandler : IActualizarPedidoInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ActualizarPedidoHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<(bool estatusOperacion, string mensaje)> Handler(PedidoDTO pedido, int idUsuario)
    {
        if (pedido.Id.Equals(0))
            return (false, "El pedido no cuenta con identificador");

        if (pedido.NombreCliente.IsNullOrEmpty() || pedido.Descripcion.IsNullOrEmpty()
            || pedido.Presio.Equals(0) || pedido.Direccion.IsNullOrEmpty())
            return (false, "Faltan campos obligatorios por capturar");

        var existePedido = await _pedidosRepocitory.GetPedidoById(pedido.Id);
        if (existePedido.IsNull())
            return (false, "El registro no existe");

        var result = await _pedidosRepocitory.Update(pedido);

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.Actualizacion,
            IdUsuario = idUsuario,
            IdRegistro = result.Id,
            NombreTabla = "Pedidos",
            AntiguoValor = JsonSerializer.Serialize(existePedido),
            NuevoValor = JsonSerializer.Serialize(result),
            FechaRegistro = DateTime.UtcNow
        });

        return (true, "Actualizacion exitosa");
    }
}
