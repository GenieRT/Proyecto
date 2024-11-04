using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData
{
    public class ISUSAContext :DbContext
    {
       
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Presentacion> Presentacions { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TurnoCarga> TurnosCargas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=ISUSA;Integrated Security=true;");
        }
    }
}
