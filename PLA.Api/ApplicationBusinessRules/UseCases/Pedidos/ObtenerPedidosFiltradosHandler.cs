using PLA.Api.Entities.POCO;
using System.Text.Json;

namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidosFiltradosHandler : IObtenerPedidosFiltradosInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ObtenerPedidosFiltradosHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<List<PedidoDTO>> Handler(string filtrado, int idUsuario)
    {
        if (filtrado.IsNullOrEmpty())
            return null;

        var pedidos = await _pedidosRepocitory.GetPedidosByFilter(filtrado);
        if (pedidos.IsNullOrEmpty())
            return null;

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
            Estatus = s.Estatus,
            Ubicacion = (0, 0)
        }).ToList();
    }
}

