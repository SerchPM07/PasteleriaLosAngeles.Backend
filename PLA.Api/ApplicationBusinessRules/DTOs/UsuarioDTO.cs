namespace PLA.Api.ApplicationBusinessRules.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public byte Telefono { get; set; }
    public string Password { get; set; }
    public bool Estatus { get; set; }
}
