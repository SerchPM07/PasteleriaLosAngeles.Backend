namespace PLA.Api.Entities.POCO;

public class RegistroActividad
{
    public long Id { get; set; }
    public byte IdTipoAccion { get; set; }
    public int IdUsuario { get; set; }
    public long IdRegistro { get; set; }
    public string NombreTabla { get; set; }
    public string AntiguoValor { get; set; }
    public string NuevoValor { get; set; }
    public DateTime FechaRegistro { get; set; }
    public virtual TipoAccion IdTipoAccionNavigation { get; set; }
    public virtual Usuario IdUsuarioNavigation { get; set; }
}
