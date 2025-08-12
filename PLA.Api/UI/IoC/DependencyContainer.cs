using Microsoft.AspNetCore.Http.Json;

namespace PLA.Api.UI.IoC;

public static class DependencyContainer
{
    internal static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
           {
             new OpenApiSecurityScheme
             {
               Reference = new OpenApiReference
               {
                 Type = ReferenceType.SecurityScheme,
                 Id = "Bearer"
               }
              },
              new string[] { }
            }
            });
        });
        builder.Services.AddUseCasePLA();
        builder.Services.AddControllersPLA();
        builder.Services.AddRepocitoryPLA(builder.Configuration, "PLAConnection");
        builder.Services.AddAuthenticationToken(builder.Configuration);
        //builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.IncludeFields = true);
        return builder.Build();
    }

    internal static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseUsuarioEndpoints();
        app.UsePedidosEndpoints();
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}
