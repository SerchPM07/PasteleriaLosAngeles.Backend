using System.Text.Json;

namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class RegistrarPedidoHandler : IRegistrarPedidoInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public RegistrarPedidoHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<(bool estatusOperacion, string mensaje)> Handler(PedidoDTO pedido, int idUsuario)
    {
        if (pedido.NombreCliente.IsNullOrEmpty() || pedido.Descripcion.IsNullOrEmpty()
                    || pedido.Presio.Equals(0) || pedido.Direccion.IsNullOrEmpty())
            return (false, "Faltan campos obligatorios por capturar");

        pedido.IdUsuario = idUsuario;
        var result = await _pedidosRepocitory.Add(pedido);

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.Registro,
            IdUsuario = idUsuario,
            IdRegistro = result.Id,
            NombreTabla = "Pedidos",
            NuevoValor = JsonSerializer.Serialize(result),
            FechaRegistro = DateTime.UtcNow
        });

        return (true, "Registro exitoso");
    }
}
