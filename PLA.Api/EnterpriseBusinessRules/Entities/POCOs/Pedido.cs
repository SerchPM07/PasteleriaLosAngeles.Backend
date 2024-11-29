namespace PLA.Api.Entities.POCO;

public class Pedido
{
    public long Id { get; set; }
    public int IdUsuario { get; set; }
    public string NombreCliente { get; set; }
    public string Descripcion { get; set; }
    public string Comentario { get; set; }
    public decimal Presio { get; set; }
    public decimal? Anticipo { get; set; }
    public DateTime FechaEntrega { get; set; }
    public string Direccion { get; set; }
    public Geometry Ubicacion { get; set; }
    public virtual Usuario IdUsuarioNavigation { get; set; }
}
