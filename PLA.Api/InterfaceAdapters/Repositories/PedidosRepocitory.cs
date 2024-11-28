namespace PLA.Api.InterfaceAdapters.Repositories;

public class PedidosRepocitory : IPedidosRepocitory
{
    private readonly PasteleriaDbContext _db;
    public PedidosRepocitory(PasteleriaDbContext db) => (_db) = (db);

    public async ValueTask<Pedido> Add(Pedido pedido)
    {
        _db.Add(pedido);
        await _db.SaveChangesAsync();
        return pedido;
    }

    public async ValueTask<Pedido> GetPedidoById(long id) =>
        await _db.Pedidos.FirstOrDefaultAsync(f => f.Id == id);

    public async ValueTask<List<Pedido>> GetPedidosByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd) =>
        await _db.Pedidos.Where(w => w.FechaEntrega >= dateTimeStart.CleanDateTime(false) && w.FechaEntrega <= dateTimeEnd.CleanDateTime(true)).ToListAsync();


    public async ValueTask<List<Pedido>> GetPedidosByFilter(string filter) =>
        await _db.Pedidos.Where(w => w.NombreCliente.ToUpper().Contains(filter.ToUpper())).ToListAsync();

    public async ValueTask<Pedido> Update(Pedido pedido)
    {
        var pedidoTmp = await _db.Pedidos.FirstOrDefaultAsync(f => f.Id == pedido.Id);
        pedidoTmp.NombreCliente = pedido.NombreCliente;
        pedidoTmp.Comentario = pedido.Comentario;
        pedidoTmp.Descripcion = pedido.Descripcion;
        pedidoTmp.Presio = pedido.Presio;
        pedidoTmp.Anticipo = pedido.Anticipo;
        pedidoTmp.Direccion = pedido.Direccion;
        
        await _db.SaveChangesAsync();
        return pedidoTmp;
    }   
}
