using Microsoft.EntityFrameworkCore;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("MiConexion"));
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<CuentaPeso> CuentaPeso { get; set; }
        public DbSet<CuentaDolar> CuentaDolar { get; set; }
        public DbSet<CuentaCripto> CuentaCripto { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
    }
}
