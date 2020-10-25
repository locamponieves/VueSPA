using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Clients>      Clients      { get; set; }
        public DbSet<Orders>       Orders       { get; set; }
        public DbSet<DetailOrders> DetailOrders { get; set; }
        public DbSet<Products>     Products     { get; set; }
    }
}