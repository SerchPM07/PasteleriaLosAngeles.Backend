namespace PLA.Api.InterfaceAdapters.Services;

public static class DependencyContainer
{
    public static IServiceCollection AddAuthenticationToken(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITokenService, TokenServices>();
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(configuration["JWT:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateLifetime = true
                };
            });
        return services;
    }
}

