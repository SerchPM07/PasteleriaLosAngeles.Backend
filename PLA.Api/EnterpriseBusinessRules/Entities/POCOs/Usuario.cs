namespace PLA.Api.Entities.POCO;
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public byte Telefono { get; set; }
    public string Password { get; set; }
    public bool Estatus { get; set; }
    public virtual ICollection<Pedido> Pedidos { get; set; }
    public virtual ICollection<RegistroActividad> RegistroActividades { get; set; }
}
