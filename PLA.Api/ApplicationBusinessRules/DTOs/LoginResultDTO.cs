namespace PLA.Api.ApplicationBusinessRules.DTOs;

public class LoginResultDTO
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; }
    public string AccessToken { get; set; }
}