using DataAccess.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class DataContext : IdentityDbContext
    {
        // En el parámetro viene la cadena de conexión
        // con base se sobrecarga el constructor de la clase heredada(DbContext)
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Clients>      Clients      { get; set; }
        public DbSet<Orders>       Orders       { get; set; }
        public DbSet<DetailOrders> DetailOrders { get; set; }
        public DbSet<Products>     Products     { get; set; }

        // Se va escribir cuando se está creando el modelo
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Le pasamos nuestras configuraciones
            new ClientConfig(builder.Entity<Clients>());
            new ProductsConfig(builder.Entity<Products>());
        }
    }
}