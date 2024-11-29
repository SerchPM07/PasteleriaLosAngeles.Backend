namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerUsuario : IControllerObtenerUsuario
{
    private readonly IObtenerUsuarioInputPort _inputPort;
    public ControllerObtenerUsuario(IObtenerUsuarioInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, UsuarioDTO usuario)> ObtenerUsuario(int idUsuario)
    {
		try
		{
            var usuario = await _inputPort.Handler(idUsuario);
            return (usuario.IsNull() ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, usuario);
		}
		catch (Exception)
		{
            return (StatusCodes.Status500InternalServerError, null);
		}
    }
}

