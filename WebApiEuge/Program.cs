
using ProyectoIntegradorAccesData.EntityFramework.SQL;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using ProyectoIntegradorLogicaAplicacion.CasosDeUso;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;

namespace WebApiEuge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //inicializacion de repositorios
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();
            builder.Services.AddScoped<IRepositorioPresentaciones, RepositorioPresentaciones>();
            builder.Services.AddScoped<IRepositorioProductos, RepositorioProductos>();
            builder.Services.AddScoped<IRepositorioReservas, RepositorioReservas>();
            builder.Services.AddScoped<IRepositorioTurnosCarga, RepositorioTurnosCarga>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();

            //inicialización de casos de uso
            builder.Services.AddScoped<IRegistrarPedido, RegistrarPedidoCU>();

            builder.Services.AddScoped<IRegistro, RegistroCU>();
            builder.Services.AddScoped<ILogin, LoginCU>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}