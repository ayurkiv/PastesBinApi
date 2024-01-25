using System.Globalization;
using System.Reflection;
using Application.Abstractions;
using Application.Queries.GetById;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Presentation.Abstractions;

namespace Presentation;

public static class Extensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        
        #region Swagger
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"Pastes API - {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(builder.Environment.EnvironmentName)}",
                    Description = "An example how to create PasteBin.",
                    License = new OpenApiLicense
                    {
                        Name = "PasteAPI - License - MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

        });
        #endregion Swagger
        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
        );
        builder.Services.AddScoped<IPasteRepository, PasteRepository>();
        builder.Services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(typeof(GetByIdHandler).Assembly, typeof(GetById).Assembly));
    }
    public static void RegisterEndpointsDefinition(this WebApplication app)
    {
        var endpoints = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointsRegistration))
                        && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointsRegistration>();

        foreach (var variableEndpoint in endpoints)
        {
            variableEndpoint.Register(app);
        }
    }

}