
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_2.Models;

namespace ProyectoFinal_2.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }
    }
}
