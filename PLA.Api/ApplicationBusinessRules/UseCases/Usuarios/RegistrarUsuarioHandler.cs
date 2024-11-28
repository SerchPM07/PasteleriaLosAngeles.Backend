using PLA.Api.Entities.POCO;
using System.Text.Json;

namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class RegistrarUsuarioHandler : IRegistrarUsuarioInputPort
{
    private readonly IActividadesRepocitory _actividadesRepocitory;
    private readonly ITokenService _tokenService;
    private readonly IUsuariosRepocitory _usuariosRepocitory;

    public RegistrarUsuarioHandler(IActividadesRepocitory actividadesRepocitory, ITokenService tokenService, IUsuariosRepocitory usuariosRepocitory) =>
        (actividadesRepocitory , tokenService, usuariosRepocitory) = (_actividadesRepocitory, _tokenService, _usuariosRepocitory);

    public async ValueTask<((bool estatusOperacion, string mensaje), LoginResultDTO loginResult)> Handler(UsuarioDTO usuario)
    {
        if (usuario.Nombre.IsNullOrEmpty() || usuario.ApellidoPaterno.IsNullOrEmpty() || usuario.ApellidoMaterno.IsNullOrEmpty()
                    || usuario.Password.IsNullOrEmpty() || usuario.Telefono == 0)
            return ((false, "Faltan campos obligatorios por capturar"), null);

        var result = await _usuariosRepocitory.Add(new Usuario
        {
            Nombre = usuario.Nombre,
            ApellidoPaterno = usuario.ApellidoPaterno,
            ApellidoMaterno = usuario.ApellidoMaterno,
            Telefono = usuario.Telefono,
            Password = Crypto.EncryptStringAES(usuario.Password),
            FechaNacimiento = usuario.FechaNacimiento
        });

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.Registro,
            IdUsuario = result.Id,
            IdRegistro = result.Id,
            NombreTabla = "Usuarios",
            NuevoValor = JsonSerializer.Serialize(result),
            FechaRegistro = DateTime.UtcNow
        });

        usuario.Id = result.Id;
        string token = await _tokenService.CreateToken(usuario);
        return ((true, "Registro exitoso"), new LoginResultDTO
        {
            Id = usuario.Id,
            NombreCompleto = $"{usuario.Nombre} {usuario.ApellidoPaterno} {usuario.ApellidoMaterno}",
            AccessToken = token
        });
    }
}
