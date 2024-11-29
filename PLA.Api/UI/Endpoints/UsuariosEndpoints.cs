namespace PLA.Api.UI.Endpoints;

internal static class UsuariosEndpoints
{
    private const string NAME_CLAIM_ID = "userId";

    internal static WebApplication UseUsuarioEndpoints(this WebApplication app)
    {
        RouteGroupBuilder Group = app.MapGroup("Api/Usuarios");

        Group.MapPost("Login", async (IControllerLoginUsuario controller, UsuarioDTO usuario) =>
        {

            var (statusCode, loginResult) = await controller.LoginUsuario(usuario);
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(loginResult) : Results.Ok(loginResult);
        }).Produces<(LoginResultDTO, string)>();

        Group.MapPost("Usuario", async (IControllerRegistrarUsuario controller, UsuarioDTO usuario) =>
        {

            var (statusCode, loginResult) = await controller.RegistrarUsuario(usuario);
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(loginResult) : Results.Ok(loginResult);
        });

        Group.MapPut("Usuario", async (IControllerActualizarUsuario controller, ClaimsPrincipal claims, UsuarioDTO usuario) =>
        {
            var (statusCode, mensaje) = await controller.ActualizarUsuario(usuario, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(mensaje) : Results.Ok(mensaje);
        }).RequireAuthorization();

        Group.MapGet("Usuario", async (IControllerObtenerUsuario controller, int id) =>
        {
            var (statusCode, usuario) = await controller.ObtenerUsuario(id);
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(usuario) : Results.Ok(usuario);
        }).RequireAuthorization();
        return app;
    }
}

