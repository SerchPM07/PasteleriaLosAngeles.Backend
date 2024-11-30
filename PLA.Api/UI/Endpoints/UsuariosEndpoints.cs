﻿namespace PLA.Api.UI.Endpoints;

internal static class UsuariosEndpoints
{
    private const string NAME_CLAIM_ID = "userId";

    internal static WebApplication UseUsuarioEndpoints(this WebApplication app)
    {
        RouteGroupBuilder Group = app.MapGroup("Api/Usuarios");

        Group.MapPost("Login", async (IControllerLoginUsuario controller, UsuarioDTO usuario) =>
        {

            var (statusCode, respuesta) = await controller.LoginUsuario(usuario);
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        });

        Group.MapPost("Usuario", async (IControllerRegistrarUsuario controller, UsuarioDTO usuario) =>
        {

            var (statusCode, respuesta) = await controller.RegistrarUsuario(usuario);
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        });

        Group.MapPut("Usuario", async (IControllerActualizarUsuario controller, ClaimsPrincipal claims, UsuarioDTO usuario) =>
        {
            var (statusCode, respuesta) = await controller.ActualizarUsuario(usuario, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        }).RequireAuthorization();

        Group.MapGet("Usuario", async (IControllerObtenerUsuario controller, int id) =>
        {
            var (statusCode, respuesta) = await controller.ObtenerUsuario(id);
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        }).RequireAuthorization();
        return app;
    }
}

