using System.Text;
using DotNetEnv;
using FiltroDotnet.Config;
using FiltroDotnet.Data;
using FiltroDotnet.Repositories;
using FiltroDotnet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

Env.Load();  // Carga las variables de entorno desde un archivo .env

// Obtiene las variables de entorno necesarias para conectarse a la base de datos
var host = Environment.GetEnvironmentVariable("DB_HOST");
var databaseName = Environment.GetEnvironmentVariable("DB_NAME");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var username = Environment.GetEnvironmentVariable("DB_USERNAME");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Crea la cadena de conexión utilizando las variables de entorno
var connectionString = $"server={host};port={port};database={databaseName};uid={username};password={password}";

var builder = WebApplication.CreateBuilder(args);

// Conexión con la base de datos usando MySQL y la versión especificada
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.20-mysql")));

// Add services to the container.
// Registra los servicios
builder.Services.AddScoped<IRoomRepository, RoomServices>(); // Registra RoomServices para el repositorio de habitaciones
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeServices>(); // Registra RoomTypeServices para el repositorio de tipos de habitación
builder.Services.AddScoped<IBookingRepository, BookingServices>(); // Registra BookingServices para el repositorio de reservas
builder.Services.AddScoped<IGuestRepository, GuestServices>(); // Registra GuestServices para el repositorio de huéspedes
builder.Services.AddScoped<IUserRepository, UserServices>(); // Registra UserServices para el repositorio de usuarios
builder.Services.AddScoped<IUtilities, Utilities>(); // Registra utilidades

builder.Services.AddSingleton<Utilities>(); // Registra una instancia única de utilidades

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Establece el esquema de autenticación JWT
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false; // No requiere HTTPS para la metadata del token
    config.SaveToken = true; // Guarda el token en el contexto
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Valida el emisor del token
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"), // Emisor del token
        ValidateAudience = false,
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"), // Audiencia del token
        ValidateLifetime = true, // Valida que el token no haya expirado
        ClockSkew = TimeSpan.Zero, // No permite desincronización de reloj
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!)) // Clave de firma del token
    };
});

builder.Services.AddControllers();
// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = ".NET Module Performance Test", // Título del API
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Camilo Barreneche Escobar", // Información de contacto
            Email = "barrecami@gmail.com",
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "This performance test seeks to develop a RESTful API that allows a hotel to manage its reservations.", // Descripción del esquema de seguridad
        Name = "Authorization",
        In = ParameterLocation.Header, // El token se envía en el encabezado de la solicitud
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configura el pipeline de manejo de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en desarrollo
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET Test"); // Configura la interfaz de usuario de Swagger
    });
}

app.UseHttpsRedirection(); // Redirige a HTTPS

app.UseAuthentication(); // Habilita la autenticación

app.UseAuthorization(); // Habilita la autorización

app.UseWelcomePage(new WelcomePageOptions
{
    Path = "/" // Configura la página de bienvenida
});

app.MapControllers(); // Mapea los controladores a las rutas

app.Run(); // Inicia la aplicación
