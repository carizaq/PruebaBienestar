using Bienestar.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bienestar.Negocio
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Usuario> Usuarios { get; set; }
    }
}
