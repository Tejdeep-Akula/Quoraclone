using QuoraClone.MYDB;
using QuoraClone.Services;
using QuoraClone.Interfaces;
using QuoraClone.Controllers;
using QuoraClone.Repositories;
using Microsoft.OpenApi.Models;
using QuoraClone;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Configure Swagger document
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });

    // Define security definition for API key
    c.AddSecurityDefinition("X-API-KEY", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });

    // Add security requirement for API key
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "X-API-KEY"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { key, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});
//Environment variables configuration 
builder.Services.Configure<SQLDB>(builder.Configuration.GetSection(nameof(SQLDB)));
//Dependency Injection
builder.Services.AddScoped<IService, QuoraService>();
builder.Services.AddScoped<IRepo, QuoraRepo>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();
app.Run();

