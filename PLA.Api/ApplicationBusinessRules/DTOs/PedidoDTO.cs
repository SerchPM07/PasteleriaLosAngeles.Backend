namespace PLA.Api.ApplicationBusinessRules.DTOs;

public class PedidoDTO
{
    public long Id { get; set; }
    public string NombreUsuario { get; set; }
    public string NombreCliente { get; set; }
    public string Descripcion { get; set; }
    public string Comentario { get; set; }
    public decimal Presio { get; set; }
    public decimal? Anticipo { get; set; }
    public DateTime FechaEntrega { get; set; }
    public string Direccion { get; set; }
    public bool Estatus { get; set; }
    public (double latitud, double longitud) Ubicacion { get; set; }
}

