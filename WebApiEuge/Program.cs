
using ProyectoIntegradorAccesData.EntityFramework.SQL;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using ProyectoIntegradorLogicaAplicacion.CasosDeUso;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;
using System.Text.Json.Serialization;
using WebApiVersion3.Services;

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

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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



            // Configura los servicios adicionales (email services)
            builder.Services.AddScoped<IEmailService>(provider => new EmailService(
                smtpServer: "smtp.gmail.com",            // Servidor SMTP de Gmail
                smtpPort: 587,                           // Puerto seguro de Gmail
                smtpUser: "soporte.isusa.t@gmail.com",     // Tu dirección de correo
                smtpPassword: "knwywvayanfenjhq" // La contraseña de aplicación generada
            ));


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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}