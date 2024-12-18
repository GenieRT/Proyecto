
using ProyectoIntegradorAccesData.EntityFramework.SQL;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using ProyectoIntegradorLogicaAplicacion.CasosDeUso;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;
using System.Text.Json.Serialization;
using WebApiVersion3.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace WebApiEuge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient();

            // Configurar CORS para permitir el acceso desde el frontend de React
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")  // URL del frontend de React
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });


            // Configuración de autenticación JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
                    RoleClaimType = ClaimTypes.Role // Aquí indicamos que los roles están en el claim "role"
                };


                // Agregar eventos para registrar errores y validaciones
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception != null)
                        {
                            Console.WriteLine($"Error de autenticación: {context.Exception.Message}");
                        }

                        // Verificar si el token tiene un formato incorrecto
                        var authorizationHeader = context.Request.Headers["Authorization"].ToString();
                        if (authorizationHeader.StartsWith("Bearer Bearer "))
                        {
                            Console.WriteLine("El encabezado Authorization tiene un prefijo duplicado.");
                        }

                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        var roles = context.Principal.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value)
                        .ToList();

                        Console.WriteLine($"Roles en el token: {string.Join(", ", roles)}");
                        return Task.CompletedTask;
                    }
                };
            });



            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Ingrese el token JWT en el formato: Bearer {token}"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
                },
                new string[] {}
                }
                });

                Console.WriteLine("Swagger configurado correctamente.");
            });

            builder.Services.AddHttpContextAccessor(); //es para url del mail

            // Inicialización de repositorios
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();
            builder.Services.AddScoped<IRepositorioPresentaciones, RepositorioPresentaciones>();
            builder.Services.AddScoped<IRepositorioProductos, RepositorioProductos>();
            builder.Services.AddScoped<IRepositorioReservas, RepositorioReservas>();
            builder.Services.AddScoped<IRepositorioTurnosCarga, RepositorioTurnosCarga>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();


            // Inicialización de casos de uso
            builder.Services.AddScoped<IRegistrarPedido, RegistrarPedidoCU>();
            builder.Services.AddScoped<IListarProductos, ListarProductosCU>();
            builder.Services.AddScoped<IListarPresentaciones, ProyectoIntegradorLogicaAplicacion.CasosDeUso.ListarPresentacionesCU>();
            builder.Services.AddScoped<IListarPedidos, ListarPedidosCU>();
            builder.Services.AddScoped<IAprobarPedido, AprobarPedidoCU>();
            builder.Services.AddScoped<IRegistrarReserva, RegistrarReservaCU>();
            builder.Services.AddScoped<IRegistro, RegistroCU>();
            builder.Services.AddScoped<ILogin, LoginCU>();
            builder.Services.AddScoped<IObtenerPedidoPorId, ObtenerPedidoPorIdCU>();
            builder.Services.AddScoped<IObtenerProductoPorId, ObtenerProductoPorIdCU>();
            builder.Services.AddScoped<IListarReservas, ListarReservasCU>();
            builder.Services.AddScoped<IObtenerReservasProximaSemana, ObtenerReservasSemanaProximaCU>();
            builder.Services.AddScoped<IVerificarDemandaYProduccion, VerificarDemandaProduccionCU>();
            builder.Services.AddScoped<IRegistrarTurnoCarga, RegistraTurnoCargaCU>();
            builder.Services.AddScoped<IListarClientes, ListarClientesCU>();



            // Configura los servicios adicionales (email services)
            builder.Services.AddScoped<IEmailService>(provider => new EmailService(
                smtpServer: "smtp.gmail.com",            // Servidor SMTP de Gmail
                smtpPort: 587,                           // Puerto seguro de Gmail
                smtpUser: "soporte.isusa.t@gmail.com",     // Tu dirección de correo
                smtpPassword: "knwywvayanfenjhq" // La contraseña de aplicación generada
            ));

            // Configura el servicio para generación de tokens JWT (tokenService)
            builder.Services.AddScoped<ITokenService>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();

                // Aquí agregas el Console.WriteLine
                var secretKey = configuration["JwtSettings:SecretKey"];
                Console.WriteLine("Clave secreta usada para el token: " + secretKey); // Esta línea imprime la clave secreta

                return new TokenService(
                    configuration["JwtSettings:SecretKey"],
                    configuration["JwtSettings:Issuer"],
                    configuration["JwtSettings:Audience"]
                );
            });





            var app = builder.Build();


            // Configurar el pipeline de solicitudes HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Aplicar la política de CORS
            app.UseCors("AllowReactApp");



            //borrar despues
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"Nueva solicitud recibida: {context.Request.Method} {context.Request.Path}");
                var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                Console.WriteLine($"Authorization Header: {authorizationHeader}");
                await next.Invoke();
            });


            //autenticación
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}