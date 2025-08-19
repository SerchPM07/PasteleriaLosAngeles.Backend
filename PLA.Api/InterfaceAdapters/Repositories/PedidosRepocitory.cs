namespace PLA.Api.InterfaceAdapters.Repositories;

public class PedidosRepocitory : IPedidosRepocitory
{
    private readonly PasteleriaDbContext _db;
    public PedidosRepocitory(PasteleriaDbContext db) => (_db) = (db);

    public async ValueTask<PedidoDTO> Add(PedidoDTO pedido)
    {
        Pedido pedidoAdd = new Pedido
        {
            IdUsuario = pedido.IdUsuario,
            NombreCliente = pedido.NombreCliente,
            TelefonoCliente = pedido.TelefonoCliente,
            Comentario = pedido.Comentario,
            Descripcion = pedido.Descripcion,
            Presio = pedido.Presio,
            Anticipo = pedido.Anticipo,
            FechaEntrega = pedido.FechaEntrega,
            Direccion = pedido.Direccion,
            Ubicacion = null
        };
        _db.Pedidos.Add(pedidoAdd);
        await _db.SaveChangesAsync();
        pedido.Id = pedidoAdd.Id;
        return pedido;
    }

    public async ValueTask<PedidoDTO> GetPedidoById(long id) =>
        await _db.Pedidos
        .Include(i => i.IdUsuarioNavigation)
        .Select(s => new PedidoDTO
        {
            Id = s.Id,
            NombreUsuario = $"{s.IdUsuarioNavigation.Nombre} {s.IdUsuarioNavigation.ApellidoPaterno} {s.IdUsuarioNavigation.ApellidoMaterno}",
            Anticipo = s.Anticipo,
            Comentario = s.Comentario,
            Descripcion= s.Descripcion,
            Direccion= s.Direccion,
            Estatus = s.Estatus,
            FechaEntrega= s.FechaEntrega,
            NombreCliente= s.NombreCliente,
            TelefonoCliente = s.TelefonoCliente,
            Presio = s.Presio
        })
        .FirstOrDefaultAsync(f => f.Id == id);

    public async ValueTask<List<PedidoDTO>> GetPedidosByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd) =>
        await _db.Pedidos.Where(w => w.FechaEntrega >= dateTimeStart.CleanDateTime(false) && w.FechaEntrega <= dateTimeEnd.CleanDateTime(true))
        .Include(i => i.IdUsuarioNavigation)
        .Select(s => new PedidoDTO
        {
            Id = s.Id,
            NombreUsuario = $"{s.IdUsuarioNavigation.Nombre} {s.IdUsuarioNavigation.ApellidoPaterno} {s.IdUsuarioNavigation.ApellidoMaterno}",
            NombreCliente = s.NombreCliente,
            TelefonoCliente = s.TelefonoCliente,
            Comentario = s.Comentario,
            Descripcion = s.Descripcion,
            Presio = s.Presio,
            Anticipo = s.Anticipo,
            FechaEntrega = s.FechaEntrega,
            Direccion = s.Direccion,
            Estatus = s.Estatus
        })
        .OrderByDescending(O => O.FechaEntrega)
        .ToListAsync();

    public async ValueTask<List<PedidoDTO>> GetPedidosByFilter(string filter) =>
        await _db.Pedidos.Where(w => w.NombreCliente.ToUpper().Contains(filter.ToUpper()))
        .Include(i => i.IdUsuarioNavigation)
        .Select(s => new PedidoDTO
        {
            Id = s.Id,
            NombreUsuario = $"{s.IdUsuarioNavigation.Nombre} {s.IdUsuarioNavigation.ApellidoPaterno} {s.IdUsuarioNavigation.ApellidoMaterno}",
            NombreCliente = s.NombreCliente,
            TelefonoCliente = s.TelefonoCliente,
            Comentario = s.Comentario,
            Descripcion = s.Descripcion,
            Presio = s.Presio,
            Anticipo = s.Anticipo,
            FechaEntrega = s.FechaEntrega,
            Direccion = s.Direccion,
            Estatus = s.Estatus
        })
        .OrderByDescending(O => O.FechaEntrega)
        .ToListAsync();

    public async ValueTask<List<PedidoDTO>> GetPedidosOfDay(DateTime day) =>
        await _db.Pedidos.Where(w => w.FechaEntrega >= day.CleanDateTime(false) && w.FechaEntrega <= day.CleanDateTime(true))
        .Include(i => i.IdUsuarioNavigation)
        .Select(s => new PedidoDTO
        {
            Id = s.Id,
            NombreUsuario = $"{s.IdUsuarioNavigation.Nombre} {s.IdUsuarioNavigation.ApellidoPaterno} {s.IdUsuarioNavigation.ApellidoMaterno}",
            NombreCliente = s.NombreCliente,
            TelefonoCliente = s.TelefonoCliente,
            Comentario = s.Comentario,
            Descripcion = s.Descripcion,
            Presio = s.Presio,
            Anticipo = s.Anticipo,
            FechaEntrega = s.FechaEntrega,
            Direccion = s.Direccion,
            Estatus = s.Estatus
        })
        .OrderByDescending(O => O.FechaEntrega)
        .ToListAsync();

    public async ValueTask<List<PedidoDTO>> GetPedidosByEstatus(bool estatus) =>
         await _db.Pedidos.Where(w => w.Estatus == estatus)
        .Include(i => i.IdUsuarioNavigation)
        .Select(s => new PedidoDTO
        {
            Id = s.Id,
            NombreUsuario = $"{s.IdUsuarioNavigation.Nombre} {s.IdUsuarioNavigation.ApellidoPaterno} {s.IdUsuarioNavigation.ApellidoMaterno}",
            NombreCliente = s.NombreCliente,
            TelefonoCliente = s.TelefonoCliente,
            Comentario = s.Comentario,
            Descripcion = s.Descripcion,
            Presio = s.Presio,
            Anticipo = s.Anticipo,
            FechaEntrega = s.FechaEntrega,
            Direccion = s.Direccion,
            Estatus = s.Estatus
        })
        .OrderByDescending(O => O.FechaEntrega)
        .ToListAsync();

    public async ValueTask<PedidoDTO> Update(PedidoDTO pedido)
    {
        var pedidoTmp = await _db.Pedidos.FirstOrDefaultAsync(f => f.Id == pedido.Id);
        pedidoTmp.NombreCliente = pedido.NombreCliente;
        pedidoTmp.TelefonoCliente = pedido.TelefonoCliente;
        pedidoTmp.Comentario = pedido.Comentario;
        pedidoTmp.Descripcion = pedido.Descripcion;
        pedidoTmp.Presio = pedido.Presio;
        pedidoTmp.Anticipo = pedido.Anticipo;
        pedidoTmp.Direccion = pedido.Direccion;
        pedidoTmp.FechaEntrega = pedido.FechaEntrega;
        pedidoTmp.Estatus = pedido.Estatus;

        await _db.SaveChangesAsync();
        return pedido;
    }   
}
