namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class ObtenerUsuarioHandler : IObtenerUsuarioInputPort
{
    private readonly IActividadesRepocitory _actividadesRepocitory;
    private readonly IUsuariosRepocitory _usuariosRepocitory;

    public ObtenerUsuarioHandler(IActividadesRepocitory actividadesRepocitory, IUsuariosRepocitory usuariosRepocitory) =>
        (_actividadesRepocitory, _usuariosRepocitory) = (actividadesRepocitory, usuariosRepocitory);

    public async ValueTask<UsuarioDTO> Handler(int idUsuario)
    {
        if (idUsuario.Equals(0))
            return null;

        var usuario = await _usuariosRepocitory.GetUsuarioById(idUsuario);
        if (usuario.IsNull())
            return null;

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.Obtencion,
            IdUsuario = idUsuario,
            IdRegistro = usuario.Id,
            NombreTabla = "Usuarios",
            NuevoValor = JsonSerializer.Serialize(usuario),
            FechaRegistro = DateTime.UtcNow
        });

        return new UsuarioDTO 
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            ApellidoPaterno = usuario.ApellidoPaterno,
            ApellidoMaterno = usuario.ApellidoMaterno,
            Telefono = usuario.Telefono,
            Password = usuario.Password,
            FechaNacimiento = usuario.FechaNacimiento
        };
    }
}
