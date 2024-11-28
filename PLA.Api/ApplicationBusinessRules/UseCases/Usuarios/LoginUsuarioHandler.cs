using System.Text.Json;

namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class LoginUsuarioHandler : ILoginUsuarioInputPort
{
    private readonly IActividadesRepocitory _actividadesRepocitory;
    private readonly ITokenService _tokenService;
    private readonly IUsuariosRepocitory _usuariosRepocitory;

    public LoginUsuarioHandler(IActividadesRepocitory actividadesRepocitory, ITokenService tokenService, IUsuariosRepocitory usuariosRepocitory) =>
        (actividadesRepocitory, tokenService, usuariosRepocitory) = (_actividadesRepocitory, _tokenService, _usuariosRepocitory);

    public async ValueTask<((bool estatusOperacion, string mensaje), LoginResultDTO loginResult)> Handler(UsuarioDTO usuario)
    {
        if (usuario.Telefono.Equals(0) || usuario.Password.IsNullOrEmpty())
            return ((false, "Datos de acceso incompletos"), null);

        var usuarioExiste = await _usuariosRepocitory.GetUsuarioByTelefono(usuario.Telefono);
        if(usuarioExiste.IsNull())
            return ((false, "El usuario no existe"), null);

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.Obtencion,
            IdUsuario = usuarioExiste.Id,
            IdRegistro = usuarioExiste.Id,
            NombreTabla = "Usuarios",
            NuevoValor = JsonSerializer.Serialize(usuarioExiste),
            FechaRegistro = DateTime.UtcNow
        });

        usuario.Id = usuarioExiste.Id;
        usuario.Nombre = usuarioExiste.Nombre;
        string token = await _tokenService.CreateToken(usuario);
        return ((true, "Login exitoso"), new LoginResultDTO
        {
            Id = usuarioExiste.Id,
            NombreCompleto = $"{usuarioExiste.Nombre} {usuarioExiste.ApellidoPaterno} {usuarioExiste.ApellidoMaterno}",
            AccessToken = token
        });
    }
}

