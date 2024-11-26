namespace PLA.Api.Entities.POCO;

public class TipoAccion
{
    public byte Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public virtual ICollection<RegistroActividad> RegistroActividades { get; set; }
}
