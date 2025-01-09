namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class ActualizarPasswordHandler : IActualizarPasswordInputPort
{
    private readonly IActividadesRepocitory _actividadesRepocitory;
    private readonly IUsuariosRepocitory _usuariosRepocitory;

    public ActualizarPasswordHandler(IActividadesRepocitory actividadesRepocitory, IUsuariosRepocitory usuariosRepocitory) => 
        (_actividadesRepocitory, _usuariosRepocitory) = (actividadesRepocitory, usuariosRepocitory);

    public async ValueTask<(bool estatusOperacion, string mensaje)> Handler(int idUsuario, PasswordDTO password)
    {
        if (password.Password.IsNullOrEmpty() || password.NewPassword.IsNullOrEmpty())
            return (false, "Faltan campos obligatorios por capturar");

        if (Crypto.DecryptStringAES(password.NewPassword).IsNullOrEmpty())
            return (false, "La contraseña no es valida");

        var passwordTmp = await _usuariosRepocitory.GetPassword(idUsuario);
        if (passwordTmp.IsNullOrEmpty())
            return (false, "El usuario no existe");

        if(passwordTmp != password.Password)
            return (false, "La contraseña actual es incorrecta");

        var result = await _usuariosRepocitory.UpdatePassword(idUsuario, password);
        if (!result)
            return (false, "No se pudo actualizar la contraseña");        

        await _actividadesRepocitory.Registrar(new RegistroActividad
        {
            IdTipoAccion = (byte)TipoAccionEnum.Actualizacion,
            IdUsuario = idUsuario,
            IdRegistro = idUsuario,
            NombreTabla = "Usuarios",
            NuevoValor = password.NewPassword,
            AntiguoValor = password.Password,
            FechaRegistro = DateTime.UtcNow
        });

        return (true, "La contraseña se actualizo correctamente");
    }
}
