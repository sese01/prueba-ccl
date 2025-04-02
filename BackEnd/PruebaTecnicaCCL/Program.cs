using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        ValidateIssuer = true,
        ValidateAudience = true,
    };

});

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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
