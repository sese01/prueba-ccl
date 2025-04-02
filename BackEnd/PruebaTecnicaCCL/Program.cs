using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Data.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Configuration.AddJsonFile("appsettings.json");
string secretKey = builder.Configuration.GetSection("Settings:SecretKey").Value;
byte[] keyToBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(settings =>
{ 
    settings.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    settings.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(settings => 
{ 
    settings.RequireHttpsMetadata = false;
    settings.SaveToken = true;
    settings.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyToBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
    };
    settings.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userClaims = context.Principal.Claims;
            var nameIdClaim = userClaims.Where(x => x.Value.Equals("hola@hola.com")).FirstOrDefault().Value;

            if (!nameIdClaim.Equals("hola@hola.com"))
            {
                context.Fail("Usuario no autorizado");
            }

            return Task.CompletedTask;
        }
    };

});

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



// Aplicar CORS

// Obtener la cadena de conexión desde appsettings.json
string connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

// Configurar el DbContext con PostgreSQL
builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Prueba Tecnica CCL");
    });
}

app.UseCors("AllowAngular");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();