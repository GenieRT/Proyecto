using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData
{
    public class ISUSAContext : DbContext
    {
       
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Presentacion> Presentacions { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TurnoCarga> TurnosCargas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
       .UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=ISUSA;Integrated Security=true;",
           sqlOptions => sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null))
       .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<LineaPedido>()
                .HasOne(lp => lp.Pedido)
                .WithMany(p => p.Productos)
                .HasForeignKey(lp => lp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LineaPedido>()
                .HasOne(lp => lp.Producto)
                .WithMany()
                .HasForeignKey(lp => lp.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Cliente)
            .WithMany()
            .HasForeignKey(r => r.ClienteId)
            .OnDelete(DeleteBehavior.Restrict); // Cambia Cascade por Restrict

            modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Cliente)
    .       WithMany()
            .HasForeignKey(p => p.ClienteId)
    .       OnDelete(DeleteBehavior.Restrict); // Cambia Cascade por Restrict

            modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Pedido)
            .WithMany()
            .HasForeignKey(r => r.PedidoId)
            .OnDelete(DeleteBehavior.Restrict); // Cambia Cascade por Restrict

            modelBuilder.Entity<LineaPedido>()
            .HasKey(lp => new { lp.ProductoId, lp.PresentacionId, lp.PedidoId });
        }

    }
}
