using Microsoft.EntityFrameworkCore;
using L01_2020VA601.Models;

namespace L01_2020VA601.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
        
        }

        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}
