using Bienestar.Data.Configurations;
using Bienestar.Entities;
using Bienestar.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bienestar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new UsuarioConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());                       

            modelBuilder.Entity<RelacionPadreHijo>().HasKey(p=>new { p.PadreId,p.HijoId });
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Padre> Padres { get; set; }
        public DbSet<Hijo> Hijos { get; set; }
        public DbSet<RelacionPadreHijo> RelacionPadreHijos { get; set; }
    }

}
