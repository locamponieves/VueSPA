using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        // En el parámetro viene la cadena de conexión
        // con base se sobrecarga el constructor de la clase heredada(DbContext)
        public DataContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        public DbSet<Clients>      Clients      { get; set; }
        public DbSet<Orders>       Orders       { get; set; }
        public DbSet<DetailOrders> DetailOrders { get; set; }
        public DbSet<Products>     Products     { get; set; }
    }
}