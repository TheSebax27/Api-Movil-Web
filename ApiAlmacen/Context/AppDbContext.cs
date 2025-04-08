using ApiAlmacen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAlmacen.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> usuario { get; set; }
        public DbSet<TipoUsuario> tipoUsuario { get; set; }


    }
}
