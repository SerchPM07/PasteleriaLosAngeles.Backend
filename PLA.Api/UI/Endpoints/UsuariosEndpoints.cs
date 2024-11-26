namespace PLA.Api.UI.Endpoints;

internal static class UsuariosEndpoints
{
    internal static WebApplication UseUsuarioEndpoints(this WebApplication app)
    {
        RouteGroupBuilder Group = app.MapGroup("Usuarios");
        return app;
    }
}

