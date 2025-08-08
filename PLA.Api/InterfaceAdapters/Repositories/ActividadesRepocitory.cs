
namespace PLA.Api.InterfaceAdapters.Repositories;

public class ActividadesRepocitory : IActividadesRepocitory
{
    private readonly PasteleriaDbContext _db;
    public ActividadesRepocitory(PasteleriaDbContext dbContext) => (_db) = (dbContext);

    public async ValueTask<bool> Registrar(RegistroActividad registro)
    {
        _db.RegistroActividades.Add(registro);
        await _db.SaveChangesAsync();
        return true;
    }
}
