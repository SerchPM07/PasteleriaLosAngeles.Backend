using System.Text.Json;

namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class ActualizarUsuarioHandler : IActualizarUsuarioInputPort
{
    private readonly IActividadesRepocitory _actividadesRepocitory;
    private readonly IUsuariosRepocitory _usuariosRepocitory;

    public ActualizarUsuarioHandler(IActividadesRepocitory actividadesRepocitory, IUsuariosRepocitory usuariosRepocitory) => 
        (_actividadesRepocitory, _usuariosRepocitory) = (actividadesRepocitory, usuariosRepocitory);


    public async ValueTask<(bool operacion, string mensaje)> Handler(UsuarioDTO usuario, int idUsuario)
    {
        if (usuario.Nombre.IsNullOrEmpty() || usuario.ApellidoPaterno.IsNullOrEmpty() || usuario.ApellidoMaterno.IsNullOrEmpty()
            || usuario.Password.IsNullOrEmpty() || usuario.Telefono.IsNullOrEmpty())
            return (false, "Faltan campos obligatorios por capturar");

        var usuarioExiste = await _usuariosRepocitory.GetUsuarioById(usuario.Id);
        if (usuarioExiste.IsNull())
            return (false, "El usuario no existe, verifique la información");

        var usurioValidar = await _usuariosRepocitory.GetUsuarioByTelefono(usuario.Telefono);
        if (usurioValidar.IsNotNull() && usuario.Id != usurioValidar.Id)
            return (false, "El telefono a actualizar ya existe");

        var result = await _usuariosRepocitory.Update(new Usuario
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            ApellidoPaterno = usuario.ApellidoPaterno,
            ApellidoMaterno = usuario.ApellidoMaterno,
            Telefono = usuario.Telefono,
            Password = usuario.Password,
            FechaNacimiento = usuario.FechaNacimiento
        });

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.Actualizacion,
            IdUsuario = idUsuario,
            IdRegistro = result.Id,
            NombreTabla = "Usuarios",
            NuevoValor = JsonSerializer.Serialize(result),
            AntiguoValor = JsonSerializer.Serialize(usuarioExiste),
            FechaRegistro = DateTime.UtcNow
        });
        return (true, "Actualzacion exitosa");
    }
}