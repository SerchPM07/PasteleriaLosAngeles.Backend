using PLA.Api.Entities.POCO;

namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class AutoLoginHandler : IAutoLoginInputPort
{
    private readonly IActividadesRepocitory _actividadesRepocitory;
    private readonly ITokenService _tokenService;
    private readonly IUsuariosRepocitory _usuariosRepocitory;

    public AutoLoginHandler(IActividadesRepocitory actividadesRepocitory, ITokenService tokenService, IUsuariosRepocitory usuariosRepocitory) =>
        (_actividadesRepocitory, _tokenService, _usuariosRepocitory) = (actividadesRepocitory, tokenService, usuariosRepocitory);

    public async ValueTask<((bool estatusOperacion, string mensaje), LoginResultDTO loginResult)> Handler(int idUsuario)
    {
        var usuarioExiste = await _usuariosRepocitory.GetUsuarioById(idUsuario);
        if (usuarioExiste.IsNull())
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

        string token = await _tokenService.CreateToken(new()
        {
            Id = usuarioExiste.Id,
            Nombre = $"{usuarioExiste.Nombre} {usuarioExiste.ApellidoPaterno} {usuarioExiste.ApellidoMaterno}"
        });

        return ((true, "Login exitoso"), new LoginResultDTO
        {
            Id = usuarioExiste.Id,
            NombreCompleto = $"{usuarioExiste.Nombre} {usuarioExiste.ApellidoPaterno} {usuarioExiste.ApellidoMaterno}",
            AccessToken = token
        });
    }
}
